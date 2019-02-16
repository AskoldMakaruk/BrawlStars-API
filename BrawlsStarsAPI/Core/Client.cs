using BrawlStarsAPI.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrawlStarsAPI.Core
{
    public class Client : IDisposable
    {
        public string Token { get; }
        private string name => "brawlstats| C#";
        private HttpClient client;

        /// <summary>
        /// Creates new Client.
        /// </summary>
        /// <param name="token">Can be generated in Discord with bot BrawlAPI#8520</param>
        public Client(string token)
        {
            Token = token;
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Add("User-Agent", name);
            client.DefaultRequestHeaders.Add("Authorization", Token);
            client.BaseAddress = new Uri(Utils.Base);
        }

        /// <summary>
        /// Get a player’s stats.
        /// </summary>
        /// <param name="tag">A valid player tag. Valid characters: 0289PYLQGRJCUV</param>
        /// <returns>Profile or null if not found</returns>
        public async Task<Profile> GetPlayerAsync(string tag)
        {
            tag = Utils.ConfirmTag(tag);
            HttpResponseMessage response = await client.GetAsync(Utils.Profile + "?tag=" + tag);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Profile.FromJson(json);
            }

            return null;
        }

        /// <summary>
        /// Get a club’s stats.
        /// </summary>
        /// <param name="tag">A valid club tag. Valid characters: 0289PYLQGRJCUV</param> 
        /// <returns>Clubs or null if not found</returns>
        public async Task<Club> GetClubAsync(string tag)
        {
            tag = Utils.ConfirmTag(tag);
            
            HttpResponseMessage response = await client.GetAsync(Utils.Club + "?tag=" + tag);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Club.FromJson(json);
            }
            return null;
        }

        /// <summary>
        /// Get current and upcoming events.
        /// </summary>
        /// <returns>Set of current and upcoming events (maps)</returns>
        public async Task<Events> GetEventsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(Utils.Events);
            //todo throw
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Events.FromJson(json);
            }
            return null;
        }

        /// <summary>
        /// Get the top count players/clubs/brawlers.
        /// </summary>
        /// <param name="type">Type of leaderboard.</param>
        /// <param name="count">The number of top players or clubs to fetch. If count > 200, it will return a ValueError.</param>
        public async Task<Leaderboard[]> GetLeaderboardAsync(LeaderboardType type, int count)
        {
            string s = Utils.LeaderboardToString(type);
            bool isbrawler = (int) type > 1;
            string req = $"{Utils.Leaderboard}/{(isbrawler ? "players" : s)}?count={count}{(isbrawler ? "&brawler=" + type : "")}";
        
            HttpResponseMessage response = await client.GetAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Leaderboard.FromJson(json);
            }
            return null;
        }

        /// <summary>
        /// Gets misc data such as shop and season info.
        /// </summary>
        public async Task<Misc> GetMiscAsync()
        {
            HttpResponseMessage response = await client.GetAsync(Utils.Misc);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Misc.FromJson(json);
            }
            return null;
        }

        /// <summary>
        /// Searches for bands of the provided club name.
        /// </summary>
        /// <param name="name">The query for the club search.</param>
        /// <returns></returns>
        public async Task<SearchClub[]> SearchClubAsync(string name)
        {
            HttpResponseMessage response = await client.GetAsync(Utils.ClubSearch + "?query=" + name);

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            if (response.IsSuccessStatusCode)
            {
                return SearchClub.FromJson(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
