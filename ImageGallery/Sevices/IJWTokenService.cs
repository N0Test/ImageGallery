using ImageGallery.Models;

namespace ImageGallery.Sevices
{
    public interface IJWTokenService
    {
        TokenModel Token(string username, string password);
    }
}
