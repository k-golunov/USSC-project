using MailKit.Net.Smtp;
using MimeKit;

namespace USSC.Helpers;

public class EmailSender
{
    public void SendEmail(string message, string mailTo)
    {
        var Mailmessage = new MimeMessage();
        Mailmessage.From.Add(new MailboxAddress("Моя компания", "admin@mycompany.com")); //отправитель сообщения поменять адрес
        Mailmessage.To.Add(new MailboxAddress("Моя компания",mailTo)); //адресат сообщения поменять адрес
        Mailmessage.Subject = "Сообщение от USummerSchool"; //тема сообщения 
        Mailmessage.Body = new BodyBuilder() { HtmlBody = $"<div style=\"color: orange;\">{message}</div>" }.ToMessageBody(); //тело сообщения (так же в формате HTML)

        using (SmtpClient client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, true); //либо использум порт 465
            client.Authenticate("mail@gmail.com", "secret"); //логин-пароль от аккаунта
            client.Send(Mailmessage);

            client.Disconnect(true);
            // logger.LogInformation("Сообщение отправлено успешно!");
        }
    }
}