namespace EarwormWebApp.DataStructures
{
    public class FormattedArtist
    {
        public FormattedArtist(string name, string genres, int followers)
        {
            Name = name;
            Genres = genres;
            Followers = followers;
        }

        public string Name { get; set; }
        public string Genres { get; set; }
        public int Followers { get; set; }
    }
}
