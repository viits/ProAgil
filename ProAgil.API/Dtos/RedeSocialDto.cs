using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class RedeSocialDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }

    }
}