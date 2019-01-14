using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.Extensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<AvailableValue> availableValues)
        {
            return availableValues.Select(av => new SelectListItem
            {
                Value = av.Value,
                Text = av.Text
            });
        }

        public static IEnumerable<SelectListItem> WithEmptySelection(this IEnumerable<SelectListItem> collection)
        {
            var emptySelection = new[] { new SelectListItem { Value = string.Empty, Text = "(Select)" } };

            return emptySelection.Union(collection);
        }
    }
}