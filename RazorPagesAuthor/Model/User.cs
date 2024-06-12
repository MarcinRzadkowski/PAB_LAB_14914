using System.ComponentModel.DataAnnotations;

namespace RazorPagesAuthor.Model
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public int Status { get; set; }

    }
}
