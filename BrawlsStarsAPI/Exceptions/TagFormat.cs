using System;

namespace BrawlStars.Exceptions
{
    public class TagFormat : Exception
    {
        public TagFormat(string invalidChars) : base($"An incorrect tag has been passed.\nInvalid Characters: {invalidChars}") { }
        public TagFormat() : base($"An incorrect tag has been passed.") { }
    }
}
