using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CreateToDoListItemViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Due Date")]
        [Required]
        public DateTime? DueDate { get; set; }
    }
}
