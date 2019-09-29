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
    public class NQuadTripleCallback : IJSONLDTripleCallback
    {
        public virtual object Call(RDFDataset dataset)
        {
            return RDFDatasetUtils.ToNQuads(dataset);
        }
    }
}
