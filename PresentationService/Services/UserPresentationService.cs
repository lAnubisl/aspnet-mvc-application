using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web.Security;
using DomainService.DomainModels;
using DomainService.DomainServiceInterfaces;
using DomainService.Enumerations;
using PresentationService.Helpers;
using PresentationService.Interfaces;
using PresentationService.Models.UserModels;
using PresentationService.Properties;

namespace PresentationService.Services
{
    public class UserPresentationService : IUserPresentationService
    {
        private readonly IUserDomainService userDomainService;

        public UserPresentationService(IUserDomainService userDomainService)
        {
            this.userDomainService = userDomainService;
        }

        public CookieModel LoadCookieModel(string email)
        {
            var user = userDomainService.LoadByEmail(email);

            if (user != null)
            {
                var model = new CookieModel
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = user.Role
                    };

                return model;
            }

            return null;
        }

        public CookieModel LoadCookieModel(LogOnService service, string accessToken)
        {
            switch (service)
            {
                case LogOnService.Facebook:
                    return LoginServiceUser<FacebookUser>(Settings.Default.FacebookApiUrl, accessToken);
                case LogOnService.Google:
                    return LoginServiceUser<GoogleUser>(Settings.Default.GoogleApiUrl, accessToken);
                default:
                    return null;
            }
        }

        public bool ValidatePassword(LogOnUserModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var user = userDomainService.LoadByEmail(model.Email) as RegisteredUser;
            return user != null && PasswordHashHelper.ValidatePassword(user, model.Password);
        }

        public bool RegisterNewUser(RegisterUserModel model)
        {
            if (model == null)
            {
                return false;
            }

            var user = new RegisteredUser
                {
                    Email = model.Email,
                    Role = Role.User
                };

            var password = Membership.GeneratePassword(6, 0);

            EmailSenderHelper.SendNewUserMessage(user, password);

            user.Password = PasswordHashHelper.HashPassword(password);

            userDomainService.Save(user);

            return true;
        }

        private static T GetEntityFromJson<T>(string url) where T : class
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    return (T)jsonSerializer.ReadObject(responseStream);
                }
            }
            catch (WebException)
            {
            }

            return null;
        }

        private CookieModel LoginServiceUser<T>(string apiUrl, string token) where T : class, IServiceUser
        {
            IServiceUser serviceUser = GetEntityFromJson<T>(string.Concat(apiUrl, token));
            if (serviceUser != null)
            {
                var cookieModel = LoadCookieModel(serviceUser.Email);
                if (cookieModel != null)
                {
                    return cookieModel;
                }

                userDomainService.Save(new User
                {
                    FirstName = serviceUser.FirstName,
                    LastName = serviceUser.LastName,
                    Email = serviceUser.Email,
                    Role = Role.User
                });

                return LoadCookieModel(serviceUser.Email);
            }

            return null;
        }
    }
}