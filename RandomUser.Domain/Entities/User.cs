using System.ComponentModel.DataAnnotations;

namespace RandomUser.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Cell { get; set; }
        [Required]
        public string PictureMedium { get; set; }
        [Required]
        public string PictureLarge { get; set; }
        [Required]
        public string PictureThumbnail { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
