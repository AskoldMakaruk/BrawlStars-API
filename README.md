# Brawlstars API
 
<a href="https://www.nuget.org/packages/BrawlStars"><img src="https://img.shields.io/nuget/v/BrawlStars.svg?style=flat-square" /></a>
<a href="https://discord.me/BrawlAPI"><img src="https://img.shields.io/badge/discord-join-7289DA.svg?logo=discord&longCache=true&style=flat-square" /></a>

## Usage
Create Client using token obtained through DiscordBot BrawlAPI#8520 and get info you need.
```C#
   Client client = new Client("token");
   var player = await client.GetPlayerAsync("Q8QQ92J0");
   var club = await client.GetClubAsync(player.Club.Tag);
```
