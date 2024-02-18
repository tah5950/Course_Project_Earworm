using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;

namespace MusicLookupService.Controllers
{
    //Sets up the API Controllers
    [ApiController]
    [Route("[controller]")]
    public class MusicLookupController : ControllerBase
    {
        private string CLIENT_ID = "ea5014e5791d4faeb085220ab751c912";
        private string CLIENT_SECRET = "8ed65116a24d40aaba684571e42a3335";

        private readonly ILogger<MusicLookupController> _logger;

        //Initailizes Default logger
        public MusicLookupController(ILogger<MusicLookupController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Method to get a list of songs matching a string keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>
        /// Search response containing matches
        /// </returns>
        [HttpGet]
        [Route("GetSong")]
        public async Task<SearchResponse> GetSong(string keyword)
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(CLIENT_ID, CLIENT_SECRET));
            SpotifyClient spotifyClient = new SpotifyClient(config);

            SearchRequest request = new SearchRequest(SearchRequest.Types.Track, keyword);
            Task<SearchResponse> response = spotifyClient.Search.Item(request);
            return response.Result;
        }

        /// <summary>
        /// Get Method to get a list of Artists matching a string keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>
        /// Search response containing matches
        /// </returns>
        [HttpGet]
        [Route("GetArtist")]
        public async Task<SearchResponse> GetArtist(string keyword)
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(CLIENT_ID, CLIENT_SECRET));
            SpotifyClient spotifyClient = new SpotifyClient(config);

            SearchRequest request = new SearchRequest(SearchRequest.Types.Artist, keyword);
            Task<SearchResponse> response = spotifyClient.Search.Item(request);
            return response.Result;
        }
    }
}
