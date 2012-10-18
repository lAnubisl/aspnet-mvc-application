using System;
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

            throw new NotImplementedException();
        }
    }
}
