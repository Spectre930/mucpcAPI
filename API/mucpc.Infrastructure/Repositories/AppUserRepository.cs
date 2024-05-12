using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using mucpc.Dmain.DTO;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace mucpc.Infrastructure.Repositories;

internal class AppUserRepository : Repository<AppUser>, IAppUserRepository
{
    private readonly mucpcDbContext _db;
    private readonly IConfiguration _configuration;
    public AppUserRepository(mucpcDbContext db, IConfiguration configuration) : base(db)
    {
        _configuration = configuration;
        _db = db;
    }

    public async Task AddUser(AppUser user)
    {
        var u = await _db.AppUsers
             .Where(u => u.Email == user.Email)
             .FirstOrDefaultAsync();
        if (u is not null)
            throw new Exception("Email already Exists!");

        if (user.Password == null)
        {
            throw new Exception("The password can't be Null!");
        }

        user.Password = HashPassword(user.Password);

        await _db.AppUsers.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task ChangePassword(string oldPassword, string newPassword, long id)
    {
        var user = await _db.AppUsers.FindAsync(id) ?? throw new Exception("Admin not Found");


        if (!CheckPassword(oldPassword, user.Password))
        {
            throw new Exception("Incorrect Password");
        }
        user.Password = HashPassword(newPassword);

        _db.AppUsers.Update(user);
        await _db.SaveChangesAsync();

    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _db.AppUsers
           .Include(u => u.Role)
           .Where(u => u.Email == dto.Email)
           .FirstOrDefaultAsync();

        if (!CheckPassword(dto.Password, user.Password) || user is null)
            throw new Exception("Incorrect Email or Password!");

        return await CreateToken(user);
    }

    public async Task ResetPassword(long userId, string newPassword)
    {
        var user = await _db.AppUsers.FindAsync(userId) ?? throw new Exception("user not found!");
        user.Password = HashPassword(newPassword);
        _db.AppUsers.Update(user);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateUser(AppUser user)
    {
        var obj = await _db.AppUsers.FindAsync(user.Id) ?? throw new Exception("User Not Found!");

        obj.Email = user.Email;
        obj.RoleId = user.RoleId;

        _db.AppUsers.Update(obj);
    }

    public async Task<bool> UserExists(string email)
    {
        var user = await _db.AppUsers
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        return user != null;
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
    }
    private bool CheckPassword(string inputPassword, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, passwordHash, true);
    }
    private async Task<string> CreateToken(AppUser user)
    {

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role.RoleName.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
           _configuration.GetSection("JWT:Key").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<AppUser> GetById(long id)
    {
        return await _db.AppUsers.FindAsync(id) ?? throw new Exception("User Not Found!");
    }

    public async Task DeleteUser(long id)
    {
        var user = await _db.AppUsers.FindAsync(id) ?? throw new Exception("User Not Found!");
        _db.AppUsers.Remove(user);
        await _db.SaveChangesAsync();
    }
}
