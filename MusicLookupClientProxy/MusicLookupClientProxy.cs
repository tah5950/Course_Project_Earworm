using SpotifyAPI.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MusicLookupClientProxy
{
    //Proxy for app to use to call the webservice
    public class MusicLookupClientProxy
    {
        private HttpClient httpClient;
        
        //Initializes HttpClient with basepath and baseAddress
        public MusicLookupClientProxy() 
        {
            string basePath = "http://host.docker.internal:5000";
            httpClient = new()
            {
                BaseAddress = new Uri(basePath + "/MusicLookup")
            };
        }

        //Method calls the getSong Endpoint and parses out the list of songs from the search response.
        //Method ensures a successful status code and throws an exception if there is an error.
        //Method validates that string input is alpha numeric or $ or &. Throws an exception otherwise
        //The method returns a list of FullTracks
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

        //Method calls the getArtist Endpoint and parses out the list of artists from the search response.
        //Method ensures a successful status code and throws an exception if there is an error.
        //Method validates that string input is alpha numeric or $ or &. Throws an exception otherwise
        //The method returns a list of FullArtists
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

        //Method validates that input string is alphanumeric + $ + &.
        //Returns true if it is, false if it is not
        private bool validateInput(string input)
        {
            if (Regex.IsMatch(input, @"^[a-zA-Z0-9&$!?,. ]+$"))
            {
                return true;
            }
            return false;
        }
    }
}
