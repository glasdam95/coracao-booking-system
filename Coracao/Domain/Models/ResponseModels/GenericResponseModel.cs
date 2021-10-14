#nullable enable
using System.Collections.Generic;
using Coracao.Domain.Models.HelperModels;
using Coracao.Domain.Models.RequestsModels;

namespace Coracao.Domain.Models.ResponseModels
{
    public class GenericResponseModel
    {
        public HeaderModel? Header { get; set; }
        public List<string> asReturnValues { get; set; }

        public class HeaderModel
        {
            public List<RequestResponseModels.Addodef?> aDDODefs { get; set; }
            public List<RequestResponseModels.Asyncprop?> aSyncProps { get; set; }
            public List<object?> aAdvSyncP { get; set; }
            public List<Aaction?> aActions { get; set; }
            public List<Aobjectdef?> aObjectDefs { get; set; }

            public class Aaction
            {
                public int? eType { get; set; }
                public string sTarget { get; set; }
                public string sName { get; set; }
                public List<string> aParams { get; set; }
                public Tdata? tData { get; set; }

                public class Tdata
                {
                    public string v { get; set; }
                    public List<C?> c { get; set; }

                    public class C
                    {
                        public string v { get; set; }
                        public List<C?> c { get; set; }
                    }
                }
            }

            public class Aobjectdef
            {
                public string sName { get; set; }
                public string sType { get; set; }
                public List<Aprop?> aProps { get; set; }
                public List<Aadvp?> aAdvP { get; set; }
                public List<Aobj?> aObjs { get; set; }

                public class Aprop
                {
                    public string sN { get; set; }
                    public string sV { get; set; }
                }

                public class Aadvp
                {
                    public string sN { get; set; }
                    public Tv? tV { get; set; }

                    public class Tv
                    {
                        public string v { get; set; }
                        public List<C2?> c { get; set; }

                        public class C2
                        {
                            public string v { get; set; }
                            public List<object?> c { get; set; }
                        }
                    }
                }

                public class Aobj
                {
                    public string sName { get; set; }
                    public string sType { get; set; }
                    public List<Aprop1?> aProps { get; set; }
                    public List<object?> aAdvP { get; set; }
                    public List<Aobj1?> aObjs { get; set; }

                    public class Aprop1
                    {
                        public string sN { get; set; }
                        public string sV { get; set; }
                    }

                    public class Aobj1
                    {
                        public string sName { get; set; }
                        public string sType { get; set; }
                        public List<Aprop2?> aProps { get; set; }
                        public List<object?> aAdvP { get; set; }
                        public List<Aobj2?> aObjs { get; set; }

                        public class Aprop2
                        {
                            public string sN { get; set; }
                            public string sV { get; set; }
                        }

                        public class Aobj2
                        {
                            public string sName { get; set; }
                            public string sType { get; set; }
                            public List<Aprop3?> aProps { get; set; }
                            public List<object?> aAdvP { get; set; }
                            public List<Aobj3?> aObjs { get; set; }

                            public class Aprop3
                            {
                                public string sN { get; set; }
                                public string sV { get; set; }
                            }

                            public class Aobj3
                            {
                                public string sName { get; set; }
                                public string sType { get; set; }
                                public List<Aprop4?> aProps { get; set; }
                                public List<object?> aAdvP { get; set; }
                                public List<object?> aObjs { get; set; }

                                public class Aprop4
                                {
                                    public string sN { get; set; }
                                    public string sV { get; set; }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}