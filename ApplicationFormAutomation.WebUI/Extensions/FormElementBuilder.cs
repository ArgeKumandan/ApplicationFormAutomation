using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace ApplicationFormAutomation.WebUI.Extensions
{
    [HtmlTargetElement("formElement", TagStructure = TagStructure.Unspecified)]
    public class FormElementBuilderTagHelper : TagHelper
    {
        public Models.FormElement FormElement { get; set; }
        public int ElementIndexNumber { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //output.TagName = GetTagName();

            if(FormElement.FormElementType == Models.FormElementType.TextBox)
            {
                new TagHelperOutputs.TextBoxTagHelperBuilder(FormElement, output, ElementIndexNumber);
            }
            else
            {
                throw new Exception("ali");
            }

            base.Process(context, output);
        }

        private string GetTagName()
        {
            switch (FormElement.FormElementType)
            {
                case Models.FormElementType.TextBox:
                    return "text";
                case Models.FormElementType.CheckBox:
                    return "checkbox";
                case Models.FormElementType.RadioButton:
                    return "radiobutton";
                case Models.FormElementType.TextArea:
                    return "textarea";
                case Models.FormElementType.File:
                    return "file";
                case Models.FormElementType.SelectComboBox:
                    return "select";
                default:
                    throw new Exception("Invalid element type");
            }
        }
    }
}
