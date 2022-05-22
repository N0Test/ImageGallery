using ImageGallery.Models;
using System.Linq;

namespace ImageGallery.Sevices
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ICRUDService<UserModel> _userCRUDService;

        public AuthorizationService(ICRUDService<UserModel> userCRUDService)
        {
            _userCRUDService = userCRUDService;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = _userCRUDService.GetAll().FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            if(user == null) return null;

            return user.Password.Equals(password) ? user : null;
        }

        public UserModel Registration(UserModel user)
        {
            return _userCRUDService.CreateOrUpdate(user);
        }
    }
}
