using System;
using System.Collections.Generic;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormSubmit
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<FormAnswer> FormAnswers { get; set; }
    }
}