using ApplicationFormAutomation.WebUI.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace ApplicationFormAutomation.WebUI.TagHelperOutputs
{
    public class TextBoxTagHelperBuilder
    {
        public TextBoxTagHelperBuilder(FormElement formElement, TagHelperOutput output, int elementIndexNumber)
        {

            output.TagName = "input";
            output.Attributes.SetAttribute("id", formElement.DataKey);
            output.Attributes.SetAttribute("placeholder", formElement.Description);
            output.Attributes.SetAttribute("name", $"FormAnswer[{elementIndexNumber}].AnswerText");
            output.Attributes.SetAttribute("class", "form-control");
            if (formElement.IsRequired)
            {
                output.Attributes.SetAttribute("required", "required");
            }
            output.Content.AppendHtml($"<input type=\"hidden\" name=\"FormAnswer[{elementIndexNumber}].FormElementId\" value=\"{formElement.Id}\" />");
        }
    }
}
