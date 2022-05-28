using ImageGallery.Models;

namespace ImageGallery.Sevices
{
    public interface IAuthorizationService
    {
        TokenModel LogIn(UserModel model);
        TokenModel Registration(UserModel user);
    }
}
