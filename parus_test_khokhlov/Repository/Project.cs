using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parus_test_khokhlov.Repository
{
    [Table("Project")]
    public class Project
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название проекта")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание проекта")]
        public string Description { get; set; }
        
        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        
        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");


    }
}
