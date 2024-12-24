using System.ComponentModel.DataAnnotations;

namespace CRUDAppUsingAdo.Models
{
    public class Student
    {

        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string domain { get; set; }
     

       


       
    }
}
