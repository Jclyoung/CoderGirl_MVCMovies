using System.Collections.Generic;

namespace CoderGirl_MVCMovies.Data
{
    internal class MovieRatingRepository : IMovieRatingRepository
    {
        public List<string> GetAverageRatingByMovieName(string movieName)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetIds()
        {
            throw new System.NotImplementedException();
        }

        public string GetMovieNameById(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetRatingById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int SaveRating(string movieName, string rating)
        {
            throw new System.NotImplementedException();
        }
    }
}