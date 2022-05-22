using ImageGallery.Models;

namespace ImageGallery.Sevices
{
    public interface IAuthorizationService
    {
        UserModel LogIn(string email, string password);
        UserModel Registration(UserModel user);
    }
}
