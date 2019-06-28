using System.Collections.Generic;
using System.Linq;

namespace CoderGirl_MVCMovies.Data
{
    internal class MovieRatingRepository : IMovieRatingRepository
    {
        public static List<MovieRating> ratings = new List<MovieRating>();
        private static int nextRatingId = 1;

        public List<MovieRating> GetMovieRatings()
        {
            return ratings;
        }

        public double GetAverageRatingByMovieName(string movieName)
        {
            double averageRating = ratings.Where(mn => mn.MovieName == movieName).Average(r => r.Rating);
            return averageRating;
        }

        public List<int> GetIds()
        {
            List<int> ratingIds = ratings.Select(id => id.RatingId).ToList();
            return ratingIds;
        }

        public string GetMovieNameById(int id)
        {
            string movieName = ratings.Where(mn => mn.RatingId == id).Select(mn => mn.MovieName).SingleOrDefault();
            return movieName;
        }

        public double GetRatingById(int id)
        {
            double movieRating = ratings.Where(mr => mr.RatingId == id).Select(mr => mr.Rating).SingleOrDefault();
            return movieRating;
        }

        public int SaveRating(string movieName, double rating)
        {
            MovieRating movieRating = new MovieRating
            {
                RatingId = nextRatingId,
                MovieName = movieName,
                Rating = rating,
            };
            nextRatingId++;
            ratings.Add(movieRating);
            return movieRating.RatingId;
        }
    }
}