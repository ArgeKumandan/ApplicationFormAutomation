using System.Collections.Generic;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormSubmit
    {
        public int Id { get; set; }
        public List<FormAnswer> FormAnswer { get; set; }
    }
}