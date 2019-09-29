using JsonLD.Core;
using JsonLD.Impl;

#if !IS_CORECLR3 
using Newtonsoft.Json.Linq;
#elif IS_CORECLR3
using Newtonsoft.Json.Linq;
using System.Text.Json;
#endif

namespace JsonLD.Impl
{
    public class NQuadRDFParser : IRDFParser
    {
        /// <exception cref="JsonLD.Core.JsonLdError"></exception>
        public virtual RDFDataset Parse(JToken input)
        {
            if (input.Type == JTokenType.String)
            {
                return RDFDatasetUtils.ParseNQuads((string)input);
            }
            else
            {
                throw new JsonLdError(JsonLdError.Error.InvalidInput, "NQuad Parser expected string input."
                    );
            }
        }
    }
}
