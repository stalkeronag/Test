using MyRPC.Interfaces;
using MyRPC.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyRPC.Commands
{
    public class CommandSendGmail: ICommand
    {
        public string[] Args { get; set; }
        public string[] Flags { get; set; }
        public string Name { get; set; }

        private IConnection connection;

        private SmtpClient client;

        private MailMessage email;

        private string[] phrases;

        public CommandSendGmail(IConnection connection)
        {
            this.connection = connection;
            client = new SmtpClient("smtp.gmail.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            email = new MailMessage();
            phrases = new string[6]
            {
                "Input your email",
                "Input send email",
                "input subject",
                "Input body",
                "Input attachments",
                "input password"
            };
        }

        public async Task Execute(HandlerBytes handler)
        {
            string[] result = new string[6];
            for(int i = 0; i < phrases.Length; i++)
            {
                await handler.Invoke(Encoding.UTF8.GetBytes(phrases[i]));
                result[i] = Encoding.UTF8.GetString(await connection.Read());
            }
            string from = result[0];
            string to = result[1];
            string subject = result[2];
            string body = result[3];
            string[] files = result[4].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string pass = result[5];
            try
            {
                email.From = new MailAddress(from);
                email.To.Add(to);
                email.Subject = subject;
                email.Body = body;
                foreach(var file in files)
                {
                    email.Attachments.Add(new Attachment(Path.Combine(ServerConfig.currentDirectory, file)));
                }
                client.Credentials = new NetworkCredential(from, pass);
                client.Send(email);
                await handler.Invoke(Encoding.UTF8.GetBytes("Something like good"));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
