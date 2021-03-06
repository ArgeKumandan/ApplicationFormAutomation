﻿using ApplicationFormAutomation.WebUI.Models;
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
            output.Attributes.SetAttribute("name", $"FormAnswers[{elementIndexNumber}].AnswerText");
            output.Attributes.SetAttribute("class", "form-control");
            if (formElement.IsRequired)
            {
                output.Attributes.SetAttribute("required", "required");
            }
            if (formElement.UseMaskForFreeText)
            {
                //TODO: regex validation
            }
            output.Content.AppendHtml($"<input type=\"hidden\" name=\"FormAnswers[{elementIndexNumber}].FormElementId\" value=\"{formElement.Id}\" />");
        }
    }
}
