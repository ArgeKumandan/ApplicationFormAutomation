using ApplicationFormAutomation.WebUI.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace ApplicationFormAutomation.WebUI.TagHelperOutputs
{
    public class TextAreaTagHelperBuilder
    {
        public TextAreaTagHelperBuilder(FormElement formElement, TagHelperOutput output, int elementIndexNumber)
        {
            output.TagName = "textarea";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("id", formElement.DataKey);
            output.Attributes.SetAttribute("placeholder", formElement.Description);
            output.Attributes.SetAttribute("name", $"FormAnswers[{elementIndexNumber}].AnswerText");
            output.Attributes.SetAttribute("class", "form-control");
            output.Attributes.SetAttribute("rows", formElement.TextAreaRowCount ?? 3);
            if (formElement.IsRequired)
            {
                output.Attributes.SetAttribute("required", "required");
            }

            output.PreElement.AppendHtml($"<input type=\"hidden\" name=\"FormAnswers[{elementIndexNumber}].FormElementId\" value=\"{formElement.Id}\" />");
        }
    }
}
