using EarwormWebApp.DataStructures;
using SpotifyAPI;
using SpotifyAPI.Web;

namespace TestWebAppHelperFunctions
{
    public class Tests
    {
        List<FullTrack> tracks;
        List<FullArtist> artists;

        [SetUp]
        public void Setup()
        {
            tracks = new List<FullTrack>();
            populateTracks();
            artists = new List<FullArtist>();
            populateArtists();
        }

        //Test the conversion from Full Track to Fomatted Track to ensure string structure is correct
        [Test]
        public void TestFullTrackstoFormattedTracks()
        {
            List<FormattedTrack> formattedTracks = FormattedTrack.fullTrackstoFormattedTracks(tracks);
            Assert.AreEqual(2, formattedTracks.Count);

            Assert.AreEqual(formattedTracks[0].Name, "Track 1");
            Assert.AreEqual(formattedTracks[0].Artists, "Artist 1, Artist 2");
            Assert.AreEqual(formattedTracks[0].Duration, "02:46:40:000");
            Assert.AreEqual(formattedTracks[0].Album, "Album 1");

            Assert.AreEqual(formattedTracks[1].Name, "Track 2");
            Assert.AreEqual(formattedTracks[1].Artists, "Artist 3, Artist 4");
            Assert.AreEqual(formattedTracks[1].Duration, "02:46:40:000");
            Assert.AreEqual(formattedTracks[1].Album, "Album 2");
        }

        //Test the conversion from Full Artist to Fomatted Artist to ensure string structure is correct
        [Test]
        public void TestFullArtiststoFormattedArtists()
        {
            List<FormattedArtist> formattedArtists = FormattedArtist.fullArtiststoFormattedArtists(artists);
            Assert.AreEqual(2, formattedArtists.Count);

            Assert.AreEqual(formattedArtists[0].Name, "Artist 1");
            Assert.AreEqual(formattedArtists[0].Genres, "Genre 1, Genre 2");
            Assert.AreEqual(formattedArtists[0].Followers, 1000);

            Assert.AreEqual(formattedArtists[1].Name, "Artist 2");
            Assert.AreEqual(formattedArtists[1].Genres, "Genre 3, Genre 4");
            Assert.AreEqual(formattedArtists[1].Followers, 1001);
        }

        //Helper Method to populate list of tracks
        private void populateTracks()
        {
            FullTrack track1 = new FullTrack();
            track1.Name = "Track 1";
            track1.DurationMs = 10000000;
            track1.Artists = new List<SimpleArtist>();

            SimpleArtist artist1 = new SimpleArtist();
            artist1.Name = "Artist 1";

            SimpleArtist artist2 = new SimpleArtist();
            artist2.Name = "Artist 2";

            track1.Artists.Add(artist1);
            track1.Artists.Add(artist2);

            track1.Album = new SimpleAlbum();
            track1.Album.Name = "Album 1";

            tracks.Add(track1);

            FullTrack track2 = new FullTrack();
            track2.Name = "Track 2";
            track2.DurationMs = 10000000;
            track2.Artists = new List<SimpleArtist>();

            SimpleArtist artist3 = new SimpleArtist();
            artist3.Name = "Artist 3";

            SimpleArtist artist4 = new SimpleArtist();
            artist4.Name = "Artist 4";

            track2.Artists.Add(artist3);
            track2.Artists.Add(artist4);

            track2.Album = new SimpleAlbum();
            track2.Album.Name = "Album 2";

            tracks.Add(track2);
        }

        //Helper Method to populate list of artists
        private void populateArtists()
        {
            FullArtist artist1 = new FullArtist();
            artist1.Name = "Artist 1";
            artist1.Genres = new List<string>();
            artist1.Followers = new Followers();

            artist1.Genres.Add("Genre 1");
            artist1.Genres.Add("Genre 2");

            artist1.Followers.Total = 1000;

            artists.Add(artist1);

            FullArtist artist2 = new FullArtist();
            artist2.Name = "Artist 2";
            artist2.Genres = new List<string>();
            artist2.Followers = new Followers();

            artist2.Genres.Add("Genre 3");
            artist2.Genres.Add("Genre 4");

            artist2.Followers.Total = 1001;

            artists.Add(artist2);
        }
    }
}