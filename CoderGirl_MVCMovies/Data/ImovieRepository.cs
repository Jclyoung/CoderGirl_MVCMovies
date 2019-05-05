using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Data
{
    public interface IMovieRepository
    {
        int Save(Movie movie);

        List<Movie> GetMovies();
    }
}
