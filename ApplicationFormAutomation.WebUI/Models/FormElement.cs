using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormElement
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string DataKey { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        [Required]
        public Form Form { get; set; }
        public List<FormElementOption> FormElementOptions { get; set; }
        public FormElementType FormElementType { get; set; }
        public FreeTextElemenType FreeTextElemenType { get; set; }
        public string Mask { get; set; }
        public bool UseMaskForFreeText { get; set; }
        public int OrderValue { get; set; }
        public FormElement()
        {
            FormElementOptions = new List<FormElementOption>();
        }
    }
}