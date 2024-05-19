namespace mucpc.Dmain.Repositories;

public interface IEmailSender
{
    Task SendPendingVerificationEmail(string toEmail, string WorkShopName);
    Task SendRegistrationApprovedEmail(string toEmail, string WorkShopName);
    Task SendRegistrationRejectedEmail(string toEmail, string WorkShopName);
}
