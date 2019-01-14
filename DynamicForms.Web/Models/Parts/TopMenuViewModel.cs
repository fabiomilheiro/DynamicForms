using System.Collections.Generic;
using System.Linq;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.Web.Models.Parts
{
    public class TopMenuViewModel
    {
        public Dictionary<string, List<FormConfiguration>> Configurations { get; set; }
    }
}