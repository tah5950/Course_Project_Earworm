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
            var appsettings = ConfigurationManager.AppSettings;
            string basePath = appsettings["MusicLookupService"];
            httpClient = new()
            {
                BaseAddress = new Uri(basePath + "/MusicLookup")
            };
        }

        public async Task<List<FullTrack>> GetTracks(string keyword)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/GetSong?keyword=" + keyword);
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
                using HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress + "/GetArtist?keyword=" + keyword);
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
