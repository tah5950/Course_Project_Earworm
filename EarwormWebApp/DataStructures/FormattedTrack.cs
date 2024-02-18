using SpotifyAPI.Web;

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

        public static List<FormattedTrack> fullTrackstoFormattedTracks(List<FullTrack> trackList)
        {
            List<FormattedTrack> formattedTracks = new List<FormattedTrack>();
            foreach (FullTrack track in trackList)
            {
                string duration = TimeSpan.FromMilliseconds(track.DurationMs).ToString(@"hh\:mm\:ss\:fff");
                string artists = "";
                foreach (SimpleArtist artist in track.Artists)
                {
                    if (artists.Length == 0)
                    {
                        artists += artist.Name;
                    }
                    else
                    {
                        artists += ", " + artist.Name;
                    }
                }
                formattedTracks.Add(new FormattedTrack(track.Name, artists, duration, track.Album.Name));
            }
            return formattedTracks;
        }
    }
}
