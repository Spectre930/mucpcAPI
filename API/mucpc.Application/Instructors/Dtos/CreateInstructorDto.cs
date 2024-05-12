﻿namespace mucpc.Application.Instructors.Dtos;

public class CreateInstructorDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int YearsOfExpertise { get; set; }
    public string Major { get; set; }
    public string DegreeLevel { get; set; }
}
