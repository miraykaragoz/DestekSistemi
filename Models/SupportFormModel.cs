using System.ComponentModel.DataAnnotations;

namespace DestekSistemi.Models
{
    public class SupportForm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SupportSubject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}