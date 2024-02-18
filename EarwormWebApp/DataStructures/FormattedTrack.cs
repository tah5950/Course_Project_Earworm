using SpotifyAPI.Web;

namespace EarwormWebApp.DataStructures
{
    //Object used to help display track information in the UI
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

        //Helper method to convert a list to FullTracks to FormattedTracks
        //List of SimpleArtists condensed into comma separated list string.
        //Duration in milliseconds is converted to hh:mm:ss:fff format
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
