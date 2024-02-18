using NUnit.Framework;
using NUnit.Framework.Legacy;
using MusicLookupClientProxy;
using SpotifyAPI.Web;

namespace TestMusicLookupClientProxy
{
    //Integration tests to test if the running service is working
    [TestFixture]
    public class TestMusicLookupClientProxy
    {
        //Initializes a Client Proxy for the tests to use (Assumes Service is running)
        private MusicLookupClientProxy.MusicLookupClientProxy client;
        [SetUp]
        public void Setup()
        {
            client = new MusicLookupClientProxy.MusicLookupClientProxy();
        }

        //Tests if a successful get of tracks returns with expected response
        [Test]
        public void TestSuccessfulGetTracks()
        {
            List<FullTrack> testResponse = client.GetTracks("test").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count > 0);
        }

        //Tests if a successful get of artists returns with expected response
        [Test]
        public void TestSuccessfulGetArtists()
        {
            List<FullTrack> testResponse = client.GetTracks("test").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count > 0);
        }

        //Tests if a successful get of tracks returns with expected empty response
        //Uses large random number as input
        [Test]
        public void TestSuccessfulGetTracksEmpty()
        {
            List<FullTrack> testResponse = client.GetTracks("0321305451654061656116164004").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count == 0);
        }

        //Tests if a successful get of artists returns with expected empty response
        //Uses large random number as input
        [Test]
        public void TestSuccessfulGetArtistsEmpty()
        {
            List<FullTrack> testResponse = client.GetTracks("0321305451654061656116164004").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count == 0);
        }
    }
}