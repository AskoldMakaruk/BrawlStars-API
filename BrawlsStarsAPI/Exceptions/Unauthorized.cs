using System;

namespace BrawlStarsAPI.Exceptions
{
    [Serializable]
    public class Unauthorized : Exception
    {
        public Unauthorized(string url) : base($"Your API Key is invalid or blocked.\nURL: {url}") { }
    }
}
