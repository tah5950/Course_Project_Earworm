namespace EarwormWebApp.DataStructures
{
    public class FormattedTrack
    {
        public FormattedTrack(string name, string artists, string duration, string album)
        {
            Name = name;
            Artists = artists;
            Duration = duration;
            Album = album;
        }

        public string Name { get; set; }
        public string Artists { get; set; }
        public string Duration { get; set; }
        public string Album { get; set; }
    }
}
