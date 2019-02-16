using BrawlStars.Exceptions;

namespace BrawlStarsAPI.Core
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
        public static string LeaderboardToString(LeaderboardType type)
        {
            int t = (int) type;
            int i = t - 2;
            if (i >= 0)
            {
                return Brawlers[i];
            }
            else if (t >= 0 && t <= 1)
            {
                return type.ToString().ToLower();
            }
            else return null;
        }
        public static string ConfirmTag(string tag)
        {
            var tg = tag.ToUpper().Replace("O", "0").Replace("#", "");
            var allowed = "0289PYLQGRJCUV";
            if (tag.Length < 3)
            {
                throw new TagFormat();
            }

            foreach (char c in tg)
                if (!allowed.Contains(c))
                    throw new TagFormat(c.ToString());
            return tg;
        }
    }

    public enum LeaderboardType
    {
        Players,
        Clubs,
        Shelly,
        Nita,
        Colt,
        Bull,
        Jessie,
        Brock,
        Dynamike,
        Bo,
        ElPrimo,
        Barley,
        Poco,
        Ricochet,
        Penny,
        Darryl,
        Frank,
        Pam,
        Piper,
        Mortis,
        Tara,
        Spike,
        Crow,
        Leon
    }
}
