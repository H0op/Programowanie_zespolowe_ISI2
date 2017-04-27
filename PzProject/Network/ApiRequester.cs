using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace PzProject.Network
{
    class ApiRequester
    {
        private const String API_KEY =
            "e76929f8eed4783889cd3454cbef3b58";

        private TMDbClient client;

        public TMDbClient Client
        {
            get { return client; }
            private set { }
        }

        public ApiRequester()
        {
            client = new TMDbClient(API_KEY);
        }

        public Movie getMovieByIdAsync(int id)
        {
            return client.GetMovieAsync(id, MovieMethods.Images).Result;
        }

        public Model.Movie getAppMovie(int id)
        {
            Movie movieFromApi = null;
            try
            {
                movieFromApi = client.GetMovieAsync(id, MovieMethods.Images).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            Model.Movie movie = null;


            if (movieFromApi != null)
            {
                movie = new Model.Movie(
                    movieFromApi.Title,
                    movieFromApi.Overview,
                    movieFromApi.Images.Posters.ToString(),
                    MovieHelper.getHours(movieFromApi.Runtime),
                    MovieHelper.getMinutes(movieFromApi.Runtime),
                    movieFromApi.ReleaseDate.ToString()
                );
            }

            return movie;
        }
    }
}
