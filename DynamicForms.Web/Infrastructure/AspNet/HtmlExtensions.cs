using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.AspNet
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString RenderMetadata(this HtmlHelper html, FieldBase field)
        {
            return html.Partial("_FieldMetadata", field);
        }

        /// <summary>
        /// Renders the field by calling EditorFor and wraps the result in a div tag containing information about the field type and alias.
        /// </summary>
        /// <typeparam name="TModel">The type of the page model being rendered e.g. Section.</typeparam>
        /// <typeparam name="TField">The type of the field.</typeparam>
        /// <param name="html">The view HtmlHelper.</param>
        /// <param name="model">The page model.</param>
        /// <param name="field">The field object. We could get it using the field expression but its compilation causes performance to drop.</param>
        /// <param name="fieldExpressionToRenderEditorFor">The expression used to identify the field to render.</param>
        /// <remarks>
        /// You may add more information that is useful to identify parts of the fields on the client-side or for styling purposes.
        /// </remarks>
        /// <remarks>
        /// Use of this method is not mandatory. You should only use it to render fields for which you need.
        /// </remarks>
        /// <returns>The HTML to render field.</returns>
        public static MvcHtmlString RenderFieldEditorFor<TModel, TField>(
            this HtmlHelper<TModel> html,
            TModel model,
            TField field,
            Expression<Func<TModel, TField>> fieldExpressionToRenderEditorFor)
            where TField : FieldBase
        {
            var div = new TagBuilder("div");
            div.AddCssClass("field");
            AddAssignableFieldTypes(div, field);

            if (!string.IsNullOrEmpty(field.Alias))
            {
                div.AddCssClass($"field-alias-{field.Alias.ToLowerInvariant()}");
            }

            div.InnerHtml = html.EditorFor(fieldExpressionToRenderEditorFor).ToString();

            return new MvcHtmlString(div.ToString());
        }

        private static void AddAssignableFieldTypes<TField>(TagBuilder div, TField field) where TField : FieldBase
        {
            div.AddCssClass($"field-type-{field.Type.ToLowerInvariant()}");

            var fieldType = field.GetType().BaseType;

            while (fieldType != null && fieldType != typeof(FieldBase))
            {
                div.AddCssClass($"field-type-{fieldType.Name.Replace("Field", null).ToLowerInvariant()}");
                
                fieldType = fieldType.BaseType;
            }
        }
    }
}