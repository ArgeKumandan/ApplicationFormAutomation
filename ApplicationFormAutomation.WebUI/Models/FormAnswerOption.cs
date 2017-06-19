namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormAnswerOption
    {
        public int Id { get; set; }
        public FormAnswer FormAnswer { get; set; }
        public FormElementOption FormElementOption { get; set; }
    }
}