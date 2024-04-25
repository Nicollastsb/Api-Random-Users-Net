using System.ComponentModel.DataAnnotations;

namespace RandomUser.Domain.Entities
{
    public class RandomicUserLogin
    {
        [Key]
        public Guid Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string MD5 { get; set; }
        public string SHA1 { get; set; }
        public string SHA256 { get; set; }
    }
}
