using Microsoft.Extensions.Options;
using mucpc.Dmain.Repositories;
using mucpc.Infrastructure.Extension;
using System.Net;
using System.Net.Mail;

namespace mucpc.Infrastructure.Repositories;

internal class EmailSender : IEmailSender
{
    private readonly GmailSettings _gmailSettings;

    public EmailSender(IOptions<GmailSettings> gmailSettings)
    {
        _gmailSettings = gmailSettings.Value;
    }

    public async Task SendGmail(string toEmail, string htmlMessage)
    {
        string senderEmail = _gmailSettings.email;
        string appPassword = _gmailSettings.appPassword;



        // Define the SMTP client
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587, // Gmail uses port 587 for SMTP with STARTTLS
            Credentials = new NetworkCredential(senderEmail, appPassword),
            EnableSsl = true // Enable SSL for secure communication
        };

        // Set a custom display name for the sender
        string senderDisplayName = "MUCPC"; // Replace with your desired display name
        MailAddress senderAddress = new MailAddress(senderEmail, senderDisplayName);

        // Create a MailMessage object
        MailMessage mail = new MailMessage
        {
            From = senderAddress,
            Subject = "MUCPC Registration",
            Body = htmlMessage,
            IsBodyHtml = true // Set to true to enable HTML content
        };

        // Add the receiver's email address
        mail.To.Add(toEmail);

        // Send the email
        try
        {
            smtpClient.Send(mail);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task SendPendingVerificationEmail(string toEmail, string WorkShopName)
    {
        string htmlContent = $@"
               <html>

<head>
    <style>
        body {{font - family: 'Courier New', Courier, monospace;
            color: #333333;
        }}


        p {{
            margin: 20px 0;
        }}

        .workshop,
        h1 {{color: #0264ce;
        }}

        .status 
                {{color: #ff7b00;
        }}
    </style>
</head>

<body>
    <h1>Hello from MUCPC</h1>
    <p>
        We would like to inform you that your registration request for the <span class=""workshop""><b>{WorkShopName}</b></span> workshop is <span class=""status""><b>pending approval</b></span>, and we will
    get back to you soon.
    </p>

    <p>Regards,<br><span class=""workshop"">MUCPC Team.</span></p>
</body>

</html>";

        await SendGmail(toEmail, htmlContent);

    }

    public async Task SendRegistrationApprovedEmail(string toEmail, string WorkShopName)
    {
        string htmlContent = $@"
<html>

<head>
    <style>
        body {{
            font-family: 'Courier New', Courier, monospace;
            color: #333333;
        }}


        p {{
            margin: 20px 0;
        }}

        .workshop,
        h1 {{
            color: #0264ce;
        }}

        .status {{
            color: #43a700;
        }}
    </style>
</head>

<body>
    <h1>Hello from MUCPC</h1>
    <p>
        We would like to inform you that your registration request for the <span class=""workshop""><b>{WorkShopName}</b></span> workshop is <span class=""status""><b>approved</b></span>.

    </p>

    <p>Regards,<br><span class=""workshop"">MUCPC Team.</span></p>
</body>

</html>";
        await SendGmail(toEmail, htmlContent);
    }


    public async Task SendRegistrationRejectedEmail(string toEmail, string WorkShopName)
    {
        string htmlContent = $@"<html>

<head>
    <style>
        body {{
            font-family: 'Courier New', Courier, monospace;
            color: #333333;
        }}


        p {{
            margin: 20px 0;
        }}

        .workshop,
        h1 {{
            color: #0264ce;
        }}

        .status {{
            color: #da0000;
        }}
    </style>
</head>

<body>
    <h1>Hello from MUCPC</h1>
    <p>
        We are sorry to inform you that your registration request for the <span class=""workshop""><b>{WorkShopName}</b></span> workshop was <span class=""status""><b>rejected</b></span> because you didn't
        meet the minimum criteria of approval.

        <br>

    </p>

    <p>Regards,<br><span class=""workshop"">MUCPC Team.</span></p>
</body>

</html>";
        await SendGmail(toEmail, htmlContent);
    }
}
