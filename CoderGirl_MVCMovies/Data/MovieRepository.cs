using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : ImovieRepository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;

        public List<Movie> GetMovies()
        {
            return movies;
        }

        public int Save(Movie movie)
        {
            movie.ID = nextId;
            nextId++;
            movies.Add(movie);
            return movie;
        }
    }
}
