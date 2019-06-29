using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }
        public int Rating { get; set; }
        public string MovieName { get; set; }

 public MovieRating(int movieRatingId, int rating, string movieName)
        {
            MovieRatingId = movieRatingId;
            Rating = rating;
            MovieName = movieName;
        }       
    }

    public class MovieRatingRepository : IMovieRatingRepository
    {
        public List<MovieRating> movieRatings = new List<MovieRating>();
        public int movieRating_nextIdToUse = 1;

        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        public int SaveRating(string movieName, int rating)
        {
            //var mRating = movieRating.FirstOrDefault(m => m.MovieName == movieName);
            //if (mRating != null)
            //{
            if (rating == 0 || string.IsNullOrEmpty(movieName))
                return 0;
            var mRating = new MovieRating(movieRating_nextIdToUse, rating, movieName);
            movieRatings.Add(mRating);
            movieRating_nextIdToUse++;
            return mRating.MovieRatingId;
            // }
            // return 0;
        }

        /// <summary>
        /// Given an id, will return the associated rating 
        /// If the id does not exist, returns 0
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int GetRatingById(int id)
        {
            var mRating = movieRatings.Find(m => m.MovieRatingId == id);
            if (mRating != null)
            {
                return mRating.Rating;
            }
            return 0;
        }

        /// <summary>
        /// Given an id, will return the associated movie name.
        /// If the id does not exist, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMovieNameById(int id)
        {
            var mRating = movieRatings.FirstOrDefault(m => m.MovieRatingId == id);
            if (mRating != null)
            {
                return mRating.MovieName;
            }
            return null;
        }

        /// <summary>
        /// Given a movie name, returns the average rating of the movie.
        /// If there are no ratings for the movie, returns an empty list.
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        public decimal GetAverageRatingByMovieName(string movieName)
        {
            var mRating = movieRatings.Where(m => m.MovieName == movieName);
            if (mRating != null)
            {
                double avgRating = mRating.Average(m => m.Rating);
                return System.Convert.ToDecimal(avgRating);
            }
            return 0m;
        }

        /// <summary>
        /// Returns a list of all the ids of saved movie ratings
        /// </summary>
        /// <returns></returns>
        public List<int> GetIds()
        {
            //List<MovieRating> savedMovieRatingsIds = movieRating.FindAll(m => m.MovieRatingId != 0);
            List<int> ids = new List<int>();
            foreach (MovieRating mr in movieRatings)
                ids.Add(mr.MovieRatingId);
            return ids;

        }
    }
}