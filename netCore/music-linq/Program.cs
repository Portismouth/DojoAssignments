using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var oneArtist = from artist in Artists
                            where artist.Hometown == "Mount Vernon"
                            select new { artist.ArtistName, artist.Age };
            Console.WriteLine("From Mount Vernon");
            foreach (var item in oneArtist)
            {
                Console.WriteLine($"{item.ArtistName}, {item.Age}");
            }
            Console.WriteLine("-----------------");

            //Who is the youngest artist in our collection of artists?
            int min = (from artist in Artists
                            select artist.Age ).Min();
            var youngest = from artist in Artists
                            where artist.Age == min
                            select new { artist.ArtistName, artist.Age };
            Console.WriteLine("Youngest");
            foreach (var item in youngest)
            {
                Console.WriteLine($"{item.ArtistName}, {item.Age}");
            }
            Console.WriteLine("-----------------");

            //Display all artists with 'William' somewhere in their real name
            Console.WriteLine("Artists with William in their name");
            var williams = (from artist in Artists
                            where artist.RealName.Contains("William")
                            select new {artist.ArtistName, artist.RealName});
            foreach (var item in williams)
            {
                Console.WriteLine($"{item.ArtistName}, {item.RealName}");
            }
            Console.WriteLine("-----------------");

            //All groups with less than 8 characters
            Console.WriteLine("Bands with short names");
            var shortBands = (from band in Groups
                            // Grabs bands with 8 characters and removes white spaces to be more accurate
                            where band.GroupName.Replace(" ", "").Length <= 8
                            select new {band.GroupName});
            foreach (var item in shortBands)
            {
                Console.WriteLine($"{item.GroupName}");
            }
            Console.WriteLine("-----------------");
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            Console.WriteLine("Bands that have members not from NYC");
            var noNewYork = (from band in Groups
                            join artist in Artists on band.Id equals artist.GroupId
                            where artist.Hometown != "New York"
                            select new {band.GroupName}).Distinct().ToList();
            foreach (var item in noNewYork)
            {
                Console.WriteLine($"{item.GroupName}");
            }
            Console.WriteLine("-----------------");

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Console.WriteLine("WuTang Clan");
            var wuTang = (from band in Groups
                            join artist in Artists on band.Id equals artist.GroupId
                            where band.GroupName == "Wu-Tang Clan"
                            select new {artist.ArtistName}).ToList();
            foreach (var item in wuTang)
            {
                Console.WriteLine($"{item.ArtistName}");
            }
            Console.WriteLine("-----------------");
        }
    }
}
