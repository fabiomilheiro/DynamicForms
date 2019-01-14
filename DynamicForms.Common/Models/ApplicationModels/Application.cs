using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DynamicForms.Common.Models.ApplicationModels
{
    public class Application
    {
        public Application()
        {
            SelectedProducts = new List<string>();
            Applicants = new List<Applicant>
            {
                new Applicant()
            };
        }

        public string ID { get; set; }

        public List<string> SelectedProducts { get; set; }

        public List<Applicant> Applicants { get; set; }

        public ApplicationState State { get; set; }

        public ScoringResult ScoringResult { get; set; }
    }
}