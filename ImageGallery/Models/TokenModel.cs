using System;

namespace ImageGallery.Models
{
    [Serializable]
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}
