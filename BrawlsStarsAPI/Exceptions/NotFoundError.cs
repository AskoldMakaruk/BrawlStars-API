using System;
using System.Collections.Generic;
using System.Text;

namespace BrawlStars.Exceptions
{
    [Serializable]
    public class NotFoundError : Exception
    {
        public NotFoundError(string invalidChars) : base($"An incorrect tag has been passed.\nInvalid Characters: {invalidChars}") { }
    }
}
