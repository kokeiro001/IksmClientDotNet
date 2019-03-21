using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace IksmClientDotNet.Core.Services
{
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        private const string SnakeDelimiter = "_";

        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization)
                .Select(ConvertSnakeCasePropertyName)
                .ToList();
        }

        private static JsonProperty ConvertSnakeCasePropertyName(JsonProperty p)
        {
            var target = p.PropertyName;

            p.PropertyName = (target.Substring(0, 1) +
                              string.Concat(target.ToCharArray(1, target.Length - 1).Select(c => char.IsUpper(c) ? SnakeDelimiter + c.ToString() : c.ToString()))).ToLower();
            return p;
        }
    }
}
