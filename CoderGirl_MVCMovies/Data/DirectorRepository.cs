using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        private static List<Director> directors = new List<Director>();
        private static int nextId = 1;
        
        public void Delete(int id)
        {
            directors.RemoveAll(d => d.Id == id);
        }

        public Director GetById(int id)
        {
            return directors.SingleOrDefault(d => d.Id == id);
        }

        public List<Director> GetDirectors()
        {
            return directors;
        }

        public int Save(Director director)
        {
            director.Id = nextId++;
            directors.Add(director);
            return director.Id;
        }

        public void Update(Director director)
        {
            this.Delete(director.Id);
            directors.Add(director);
        }
    }
}
