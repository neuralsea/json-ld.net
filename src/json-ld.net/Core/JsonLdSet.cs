using System;
using System.Collections.Generic;

#if !IS_CORECLR3 
using Newtonsoft.Json.Linq;
#elif IS_CORECLR3
using Newtonsoft.Json.Linq;
using System.Text.Json;
#endif

namespace JsonLD.Core
{
    internal sealed class JsonLdSet
    {
        private readonly Lazy<HashSet<string>> _objects;

        internal JsonLdSet()
        {
            _objects = new Lazy<HashSet<string>>(() => new HashSet<string>(StringComparer.Ordinal));
        }

        internal bool Add(JToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (token is JObject)
            {
                var id = token["@id"];

                return id != null && _objects.Value.Add(id.Value<string>());
            }

            return false;
        }
    }
}