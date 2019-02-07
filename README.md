# Brawlstars API
 
[![package](https://img.shields.io/nuget/vpre/BrawlStars.svg?label=BrawlStars&style=flat-square)](https://www.nuget.org/packages/BrawlStars)

## Usage
Create Client using token obtained through DiscordBot BrawlAPI#8520 and get info you need.
```C#
   Client client = new Client("token");
   var player = await client.GetPlayerAsync("Q8QQ92J0");
   var club = await client.GetClubAsync(player.Club.Tag);
```
