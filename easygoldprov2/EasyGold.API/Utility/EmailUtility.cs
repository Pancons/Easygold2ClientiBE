using System.Net;
using System.Net.Mail;


namespace EasyGold.API.Utility
{
    public static class EmailUtility
    {
        public static void SendPasswordResetEmail(string recipientEmail, string resetLink)
        {
            var fromEmail = "noreply@tuodominio.com"; // Sostituisci con l'email del mittente
            var subject = "Reset della password";
            var body = $@"
            <p>Ciao,</p>
            <p>Abbiamo ricevuto una richiesta di reset della tua password.</p>
            <p>Clicca sul link seguente per reimpostare la tua password:</p>
            <p><a href='{resetLink}'>{resetLink}</a></p>
            <p>Questo link sarà valido per 1 ora.</p>
            <p>Se non hai richiesto il reset, puoi ignorare questa email.</p>
            <br>
            <p>Grazie,<br>Il team di supporto</p>";

            var smtpClient = new SmtpClient("smtp.tuodominio.com") // Es: smtp.gmail.com
            {
                Port = 587, // O 465 per SSL
                Credentials = new NetworkCredential("tuo_username", "tua_password"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "Supporto"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(recipientEmail);

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Logga o gestisci l'errore
                Console.WriteLine($"Errore nell'invio email: {ex.Message}");
                throw; // Rilancia se vuoi gestirlo più in alto
            }
        }
    }
}