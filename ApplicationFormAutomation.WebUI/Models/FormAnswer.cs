using System.Collections.Generic;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormAnswer
    {
        public int Id { get; set; }
        public int FormElementId { get; set; }
        public FormElement FormElement { get; set; }
        public string AnswerText { get; set; }
        public FormSubmit FormSubmit { get; set; }
        public List<FormAnswerOption> FormAnswerOptions { get; set; }
    }
}