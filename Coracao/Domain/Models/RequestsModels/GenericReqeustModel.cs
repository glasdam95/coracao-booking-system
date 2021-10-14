using System.Collections.Generic;
using Coracao.Domain.Models.HelperModels;

namespace Coracao.Domain.Models.RequestsModels
{
    public class GenericReqeustModel
    {
        public Actionrequest ActionRequest { get; set; }

        public class Actionrequest
        {
            public HeaderModel Header { get; set; }
            public List<Aaction> aActions { get; set; }

            public class HeaderModel
            {
                public string sFocus { get; set; }
                public List<RequestResponseModels.Addodef> aDDODefs { get; set; }
                public List<RequestResponseModels.Asyncprop> aSyncProps { get; set; }
                public List<object> aAdvSyncP { get; set; }
            }

            public class Aaction
            {
                public string sTarget { get; set; }
                public string sAction { get; set; }
                public List<string> aParams { get; set; }
                public object tData { get; set; }
            }
        }
    }
}