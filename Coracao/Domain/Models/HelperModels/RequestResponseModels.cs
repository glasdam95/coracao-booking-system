using System.Collections.Generic;

namespace Coracao.Domain.Models.HelperModels
{
    public class RequestResponseModels
    {
        public class aDDOsObject
                {
                    public string aRemembered { get; set; }
                    public string iConstrainFile { get; set; }
                    public string sName { get; set; }
                    public string sRowID { get; set; }
                }

        public class Addodef
        {
            public string sView { get; set; }
            public string sCS { get; set; }
            public List<object> aDDOs { get; set; }
        }

        public class Asyncprop
        {
            public string sO { get; set; }
            public List<Ap?> aP { get; set; }

            public class Ap
            {
                public string sN { get; set; }
                public string sV { get; set; }
            }
        }
    }
}