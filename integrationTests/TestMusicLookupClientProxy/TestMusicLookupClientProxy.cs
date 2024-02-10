using NUnit.Framework;
using NUnit.Framework.Legacy;
using MusicLookupClientProxy;
using SpotifyAPI.Web;

namespace TestMusicLookupClientProxy
{
    [TestFixture]
    public class TestMusicLookupClientProxy
    {
        private MusicLookupClientProxy.MusicLookupClientProxy client;
        [SetUp]
        public void Setup()
        {
            client = new MusicLookupClientProxy.MusicLookupClientProxy();
        }

        [Test]
        public void TestSuccessfulGetTracks()
        {
            List<FullTrack> testResponse = client.GetTracks("test").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count > 0);
        }

        [Test]
        public void TestSuccessfulGetArtists()
        {
            List<FullTrack> testResponse = client.GetTracks("test").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count > 0);
        }

        [Test]
        public void TestSuccessfulGetTracksEmpty()
        {
            List<FullTrack> testResponse = client.GetTracks("0321305451654061656116164004").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count == 0);
        }

        [Test]
        public void TestSuccessfulGetArtistsEmpty()
        {
            List<FullTrack> testResponse = client.GetTracks("0321305451654061656116164004").Result;

            ClassicAssert.IsTrue(testResponse != null);
            ClassicAssert.IsTrue(testResponse.Count == 0);
        }
    }
}