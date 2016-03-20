using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;

namespace Lab5.Mvc.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(55)]
        public String Title { get; set; }

        [MaxLength(1000)]
        public String Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompleteDateTime { get; set; }
    }
}
