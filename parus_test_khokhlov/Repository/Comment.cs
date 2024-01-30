using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parus_test_khokhlov.Repository
{
    [Table("Comments")]
    public class Comment
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Текст комментария")]
        public string Text { get; set; }
        public int? Project_taskId { get; set; }

        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

    }
}
