using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie : IModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Name must be included")]
        public string Name { get; set; }
        public string DirectorName { get; set; }
        [Required(ErrorMessage = "Not A Valid Year")]
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }
    }
}
