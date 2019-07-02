using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Director : IModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name must be included")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name must be included")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }

        }
    }
}
