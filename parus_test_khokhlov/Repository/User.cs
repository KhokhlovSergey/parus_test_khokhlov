using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parus_test_khokhlov.Repository
{
    [Table("Users")]
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

    }
}
