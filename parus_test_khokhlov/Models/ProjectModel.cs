﻿using System.ComponentModel.DataAnnotations;

namespace parus_test_khokhlov.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
