using System.ComponentModel.DataAnnotations;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormElementOption
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public FormElement FormElement { get; set; }
        public int OrderValue { get; set; }
    }
}