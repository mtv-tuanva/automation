using Automation.Web.Core;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Automation.Web.Bdd.Models
{
    public class Step
    {
        public int Order { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Action Action { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SelectorType SelectorType { get; set; }

        public string Selector { get; set; }

        public string DisplayName { get; set; }

        public string Value { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AssertCondition AssertCondition { get; set; }

    }
}
