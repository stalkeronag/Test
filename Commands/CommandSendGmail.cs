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

        public CommandSendGmail(IConnection connection)
        {
            this.connection = connection;
        }

        public void Execute(HandlerBytes handler)
        {
            string requestedFrom = "Input your email";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedFrom));
            string from = Encoding.UTF8.GetString(connection.Read());
            string requestedTo = "Input send email";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedTo));
            string to  = Encoding.UTF8.GetString(connection.Read());
            string requestedSubject = "input subject";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedSubject));
            string subject = Encoding.UTF8.GetString(connection.Read());
            string requestedBody = "Input body";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedBody));
            string body = Encoding.UTF8.GetString(connection.Read());
            string requestedAttachments = "Input attachments";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedAttachments));
            string[] files = Encoding.UTF8.GetString(connection.Read()).Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string requestedPassword = "input password";
            handler.Invoke(Encoding.UTF8.GetBytes(requestedPassword));
            string pass = Encoding.UTF8.GetString(connection.Read());
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage email = new MailMessage();
                email.From = new MailAddress(from);
                email.To.Add(to);
                email.Subject = subject;
                email.Body = body;
                foreach(var file in files)
                {
                    email.Attachments.Add(new Attachment(Path.Combine(ServerConfig.currentDirectory, file)));
                }
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, pass);
                client.Send(email);
                handler.Invoke(Encoding.UTF8.GetBytes("Something like good"));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
