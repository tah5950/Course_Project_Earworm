using SpotifyAPI.Web;

namespace EarwormWebApp.DataStructures
{
    public class FormattedArtist
    {
        //Object used to help display artist information in the UI
        public FormattedArtist(string name, string genres, int followers)
        {
            Name = name;
            Genres = genres;
            Followers = followers;
        }

        public string Name { get; set; }
        public string Genres { get; set; }
        public int Followers { get; set; }

        //Helper method to convert a list to FullArtists to FormattedArtists
        //List of Genres condensed into comma separated list string.
        public static List<FormattedArtist> fullArtiststoFormattedArtists(List<FullArtist> artistList)
        {
            List<FormattedArtist> formattedArtists = new List<FormattedArtist>();
            foreach (FullArtist artist in artistList)
            {
                string genres = "";
                foreach (string genre in artist.Genres)
                {
                    if (genres.Length == 0)
                    {
                        genres += genre;
                    }
                    else
                    {
                        genres += ", " + genre;
                    }
                }
                formattedArtists.Add(new FormattedArtist(artist.Name, genres, artist.Followers.Total));
            }
            return formattedArtists;
        }
    }
}
