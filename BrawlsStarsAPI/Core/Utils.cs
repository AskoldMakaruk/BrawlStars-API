using BrawlStars.Exceptions;

namespace BrawlStars.Core
{
    internal static class Utils
    {
        public static string Base => "https://brawlapi.cf/api";
        public static string Profile => Base + "/player";
        public static string Club => Base + "/club";
        public static string Leaderboard => Base + "/leaderboards";
        public static string Events => Base + "/events";
        public static string Misc => Base + "/misc";
        public static string ClubSearch => Base + "/club/search";
        public static string Constants => "https://fourjr.herokuapp.com/bs/constants/";

        public static string[] Brawlers => new[]
        {
            "shelly","nita","colt",
            "bull","jessie","brock",
            "dynamike","bo","el primo",
            "barley","poco","ricochet",
            "penny","darryl","frank",
            "pam","piper","mortis",
            "tara","spike","crow",
            "leon"
        };

        public static bool ConfirmTag(string tag)
        {
            var tg = tag.ToUpper().Replace("O", "0").Replace("#", "");
            var allowed = "0289PYLQGRJCUV";
            if (tag.Length < 3)
            {
                return false;
            }

            foreach (char c in tg)
                if (!allowed.Contains(c))
                    throw new NotFoundError(c.ToString());
            return true;
        }
    }
}
