using SpotifyAPI.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;

namespace MusicLookupClientProxy
{
    public class MusicLookupClientProxy
    {
        private HttpClient httpClient;
        public MusicLookupClientProxy() 
        {
            //string basePath = ConfigurationManager.AppSettings["MusicLookupService"];
            string basePath = "http://localhost:5000";
            httpClient = new()
            {
                BaseAddress = new Uri(basePath + "/MusicLookup")
            };
        }

        public async Task<List<FullTrack>> GetTracks(string keyword)
        {
            try
            {
                using HttpResponseMessage response = Task.Run(() => httpClient.GetAsync(httpClient.BaseAddress + "/GetSong?keyword=" + keyword)).Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                SearchResponse responseSearch = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);

                List<FullTrack> tracks = responseSearch.Tracks.Items.Cast<FullTrack>().ToList();

                return tracks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FullArtist>> GetArtists(string keyword)
        {
            try
            {
                using HttpResponseMessage response = Task.Run(() => httpClient.GetAsync(httpClient.BaseAddress + "/GetArtist?keyword=" + keyword)).Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                SearchResponse responseSearch = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);

                List<FullArtist> artists = responseSearch.Artists.Items.Cast<FullArtist>().ToList();

                return artists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
