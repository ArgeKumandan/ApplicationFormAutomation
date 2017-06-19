using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<FormElement> FormElements { get; set; }
        public Form()
        {
            FormElements = new List<FormElement>();
        }
    }
}
