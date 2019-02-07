using BrawlStars.Core;
using BrawlStars.Model;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrawlsStarsAPI.Core
{
    public class Client
    {
        public string Token { get; }
        private string name => "brawlstats | Python";
        private HttpClient client = new HttpClient();

        /// <summary>
        /// Creates new Client.
        /// </summary>
        /// <param name="token">Can be generated in Discord with bot BrawlAPI#8520</param>
        public Client(string token)
        {
            Token = token;
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkaXNjb3JkX3VzZXJfaWQiOiIzNjY1Nzk2MjA5NTIyNzY5OTQiLCJpYXQiOjE1NDk1Mjk3NDh9.m1_6Nwfl_5gT6VxERs-Bj26kvLRYxsSOIbLfEVsX42U";

            client.DefaultRequestHeaders.Add("User-Agent", name);
            client.DefaultRequestHeaders.Add("Authorization", Token);

            client.BaseAddress = new Uri(Utils.Base);
        }

        /// <summary>
        /// Get a player’s stats.
        /// </summary>
        /// <param name="tag">A valid player tag. Valid characters: 0289PYLQGRJCUV</param>
        public async Task<Player> GetPlayerAsync(string tag)
        {
            Player player = null;
            HttpResponseMessage response = await client.GetAsync(Utils.Profile + "?tag=" + tag);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Player>();
            }
            return player;

        }

        /// <summary>
        /// Get a club’s stats.
        /// </summary>
        /// <param name="tag">A valid club tag. Valid characters: 0289PYLQGRJCUV</param>
        public async Task<Club> GetClub(string tag)
        {
            Club club = null;
            HttpResponseMessage response = await client.GetAsync(Utils.Club + "?tag=" + tag);
            if (response.IsSuccessStatusCode)
            {
                club = await response.Content.ReadAsAsync<Club>();
            }
            return club;
        }

        /// <summary>
        /// Get current and upcoming events.
        /// </summary>
        public async Task<Events> GetEvents()
        {
            HttpResponseMessage response = await client.GetAsync(Utils.Events);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Events>();
            }
            return null;
        }

        /// <summary>
        /// Get the top count players/clubs/brawlers.
        /// </summary>
        /// <param name="type">The type of leaderboard. Must be “players”, “clubs”, or the brawler leaderboard you are trying to access. Anything else will return a ValueError.</param>
        /// <param name="count">The number of top players or clubs to fetch. If count > 200, it will return a ValueError.</param>
        public async Task<Leaderboard> GetLeaderboard(string type, int count)
        {
            bool brawler = Utils.Brawlers.Contains(type);
            HttpResponseMessage response = await client.GetAsync($"{Utils.Leaderboard}/{(brawler ? "player" : type)}?count={count}{(brawler ? "&brawler=" + type : "")}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Leaderboard>();
            }
            return null;
        }

        /// <summary>
        /// Gets misc data such as shop and season info.
        /// </summary>
        public async Task<Misc> GetMisc()
        {
            HttpResponseMessage response = await client.GetAsync(Utils.Misc);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Misc>();
            }
            return null;
        }

        /// <summary>
        /// Searches for bands of the provided club name.
        /// </summary>
        /// <param name="name">The query for the club search.</param>
        /// <returns></returns>
        public async Task<string> SearchClub(string name)
        {
            HttpResponseMessage response = await client.GetAsync(Utils.ClubSearch + "?query=" + name);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

    }
}
