using SpotifyAPI.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MusicLookupClientProxy
{
    public class MusicLookupClientProxy
    {
        private HttpClient httpClient;
        public MusicLookupClientProxy() 
        {
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
                if (!validateInput(keyword))
                {
                    throw new ArgumentException("Invalid Input");
                }
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
                if (!validateInput(keyword))
                {
                    throw new ArgumentException("Invalid Input");
                }
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

        private bool validateInput(string input)
        {
            if (Regex.IsMatch(input, @"^[a-zA-Z0-9&$]+$"))
            {
                return true;
            }
            return false;
        }
    }
}
