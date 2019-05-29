using BrawlStars.Exceptions;

namespace BrawlStarsAPI.Core
{
    public static class Utils
    {
        internal static string Base => "https://brawlapi.cf/v1";
        internal static string Profile => Base + "/player";
        internal static string Club => Base + "/club";
        internal static string Leaderboard => Base + "/leaderboards";
        internal static string Events => Base + "/events";
        internal static string Misc => Base + "/misc";
        internal static string ClubSearch => Base + "/club/search";
        internal static string Constants => "https://fourjr.herokuapp.com/bs/constants/";

        public static string[] Brawlers => new []
        {
            "shelly",
            "nita",
            "colt",
            "bull",
            "jessie",
            "brock",
            "dynamike",
            "bo",
            "el primo",
            "barley",
            "poco",
            "rico",
            "penny",
            "darryl",
            "frank",
            "pam",
            "piper",
            "mortis",
            "tara",
            "spike",
            "crow",
            "leon",
            "carl",
            "geniue"
        };
        public static string LeaderboardToString (LeaderboardType type)
        {
            int t = (int) type;
            int i = t - 2;
            if (i >= 0)
            {
                return Brawlers[i];
            }
            else if (t >= 0 && t <= 1)
            {
                return type.ToString ().ToLower ();
            }
            else return null;
        }
        public static string ConfirmTag (string tag)
        {
            var tg = tag.ToUpper ().Replace ("O", "0").Replace ("#", "");
            var allowed = "0289PYLQGRJCUV";
            if (tag.Length < 3)
            {
                throw new TagFormat ();
            }

            foreach (char c in tg)
                if (!allowed.Contains (c))
                    throw new TagFormat (c.ToString ());
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
        Leon,
        Geniue,
        Carl
    }
}