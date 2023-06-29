using MimeKit;
using MailKit.Net.Smtp;

public class Email
{
     public static void sendmailcode(string Email,string msg)
    {
        MimeMessage message = new MimeMessage();
        //get email from session
        
        MailboxAddress from = new MailboxAddress("Fitness",
        "info@hampadco.com");
        message.From.Add(from);

        MailboxAddress to = new MailboxAddress("User",
            Email);
        message.To.Add(to);

        message.Subject = "Reset Password";
       
        //save to session email and code
       

        var licenseKey = Guid.NewGuid().ToString().Trim();
        licenseKey = licenseKey.Trim();


        var qtext = "<p style='text-align:center;background-color:#0000ff2e;border-radius:10px;color:black;padding:10px'>Reset Password FitAnalyase</p><p style='text-align:center;background-color:#0000ff2e;color:black;padding:10px;border-radius:10px'>" + msg + "    </p>";
        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = qtext;
        bodyBuilder.TextBody = "Hello World!";
        message.Body = bodyBuilder.ToMessageBody();
        try
        {
             SmtpClient client = new SmtpClient();
            client.Connect("mail.hampadco.com", 465, true);
            client.Authenticate("info@hampadco.com", "Kg@1230099");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
       
        }
        catch (System.Exception ex)
        {
             // TODO
        }

       

    }
}