using System.ComponentModel.DataAnnotations;

namespace Imagestore.Models
{
    public class ImageApi
    {
        [Key]
        public int Id { get; set; }

        public string? FileName { get; set; }

        public string Data { get; set; }

    }
}
