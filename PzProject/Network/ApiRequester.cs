using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                movieFromApi = client.GetMovieAsync(id, MovieMethods.Credits).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

            Model.Movie movie = null;


            if (movieFromApi != null)
            {
                string pc = null;
                foreach (var productionCountry in movieFromApi.ProductionCountries)
                {
                    pc = pc + productionCountry.Name + ", ";
                }
                string gen = null;
                foreach (var genre in movieFromApi.Genres)
                {
                    gen = gen + genre.Name + ", ";
                }
                string dir = null;
                string sp = null;
                foreach (var crew in movieFromApi.Credits.Crew)
                {
                   if(crew.Job.ToLowerInvariant() == "director") dir = crew.Name;
                    if (crew.Job.ToLowerInvariant() == "screenplay") sp = crew.Name;
                }

                string cast = null;
                for (int i = 0; i<= 5; i++)
                {
                    cast = cast + movieFromApi.Credits.Cast[i].Name + ", ";
                }

                string adult = null;
                if (movieFromApi.Adult) adult = "Tak";
                else adult = "Nie";
               
                
                movie = new Model.Movie(
                    movieFromApi.Title,
                    movieFromApi.Overview,
                    //movieFromApi.Images.Posters.ToString(),
                    movieFromApi.PosterPath,
                    MovieHelper.getHours(movieFromApi.Runtime),
                    MovieHelper.getMinutes(movieFromApi.Runtime),
                    ((DateTime)movieFromApi.ReleaseDate).ToString("d", new CultureInfo("pl-PL")),
                    pc,
                    gen,
                    adult,
                    dir,
                    cast,
                    sp

                );
                
            }

            return movie;
        }
    }
}
