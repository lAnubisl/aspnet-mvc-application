using System;
using Anubis.Utils;
using DomainService.DomainModels;

namespace PresentationService.Helpers
{
    public static class EmailSenderHelper
    {
        public static void SendNewUserMessage(User user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var sender = new EmailSender();
            sender.FireEmail(user.Email, user.ToString(), "new user", password);
        }
    }
}
