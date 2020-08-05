using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FamillyShare.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        [NotMapped] 
        public IFormFile PhotoFile { get; set; }
    }
}
