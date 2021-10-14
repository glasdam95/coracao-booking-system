using System.Collections.Generic;
using Coracao.Domain.Managers.Abstractions;
using Coracao.Domain.Models.Abstractions;
using Coracao.Domain.Models.HelperModels;
using Coracao.Domain.Models.RequestsModels;
using Coracao.Domain.Models.ResponseModels;

namespace Coracao.Domain.Managers
{
    public class ConstructionModelManager : IConstructionModelManager
    {
        public ISessionManager SessionManager;

        public ConstructionModelManager(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }

        #region Authentication

        public GenericReqeustModel CreatePreLoadingModel()
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "1"
                            },
                            sAction = "LoadWebApp",
                            sTarget = "",
                            tData = null
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel()
                }
            };
        }

        public GenericReqeustModel CreateAuthenticationModel(IAuthenticationRequestModel authenticationModel)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            sAction = "OnSubmit",
                            sTarget = "oLoginDialog",
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = new List<RequestResponseModels.Addodef>
                        {
                            new RequestResponseModels.Addodef
                            {
                                sCS = SessionManager.FlowToken,
                                sView = "oLoginDialog"
                            }
                        },
                        aSyncProps = new List<RequestResponseModels.Asyncprop>
                        {
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = authenticationModel.Username
                                    }
                                },
                                sO = "oLoginDialog.oMainPanel.oLoginName"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = authenticationModel.Password
                                    }
                                },
                                sO = "oLoginDialog.oMainPanel.oPassword"
                            }
                        }
                    }
                }
            };
        }

        #endregion

        #region Flow

        public GenericReqeustModel CreateInitializationRequestModel()
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "oVisBFTxt",
                                "",
                                "0"
                            },
                            sAction = "loadView"
                        }
                    }
                }
            };
        }

        public GenericReqeustModel CreateOnShowRequestModel(List<RequestResponseModels.Addodef> defsList)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>(),
                            sAction = "OnShow",
                            sTarget = "oVisBFTxt"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = defsList,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>()
                    }
                }
            };
        }

        public GenericReqeustModel CreateBookingViewRequestModel(List<RequestResponseModels.Addodef> defsList)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "oBookLejl",
                                "oVisBFTxt",
                                "0"
                            },
                            sAction = "loadView",
                            sTarget = ""
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = defsList,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>()
                    }
                }
            };
        }

        public GenericReqeustModel CreateNewBookingRequestModel(List<RequestResponseModels.Addodef> defsList)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "103",
                                ""
                            },
                            sAction = "OnChange",
                            sTarget = "oBookLejl.oWebMainPanel.oLejlCmb"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = defsList,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>
                        {/*
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "071"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oAndelCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oYearCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "103"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oLejlCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "33"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oBookOversigt.oBook_uge"
                            },*/
                        },
                        sFocus = "oBookLejl.oWebMainPanel.oLejlCmb"
                    }
                }
            };
        }

        public GenericReqeustModel CreateInitialBookingRequestModel(List<RequestResponseModels.Addodef> defsList)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>(),
                            sAction = "OnShow",
                            sTarget = "oBookLejl"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = defsList,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>()
                    }
                }
            };
        }

        public GenericReqeustModel CreateDecideBookingRequestModel(List<RequestResponseModels.Addodef> aDdOs,
            List<RequestResponseModels.Asyncprop?> asyncprops)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "613a0000"
                            },
                            sAction = "OnRowClick",
                            sTarget = "oBookLejl.oWebMainPanel.oBookOversigt"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = aDdOs,
                        aSyncProps = asyncprops,//new List<RequestResponseModels.Asyncprop>
                        /*{
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "071"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oAndelCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oYearCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "103"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oBookLejl.oWebMainPanel.oLejlCmb"
                            },
                            new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop
                            {
                                aP = new List<GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap>
                                {
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "piCurrentRowIndex",
                                        sV = "33"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psCurrentRowID",
                                        sV = "613a0000"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "piRowCount",
                                        sV = "52"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "piSortColumn",
                                        sV = "0"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbReverseOrdering",
                                        sV = "0"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "peUpdateMode",
                                        sV = "2"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "piInitialColumn",
                                        sV = "-1"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "piUpdateColumn",
                                        sV = "0"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psSeedValue",
                                        sV = ""
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbAutoSeed",
                                        sV = "0"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psPromptUpdateCallback",
                                        sV = ""
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "psInvokingObject",
                                        sV = "oBookLejl.oWebMainPanel.oLejlCmb"
                                    },
                                    new GenericReqeustModel.Actionrequest.HeaderModel.Asyncprop.Ap
                                    {
                                        sN = "pbUnOrdered",
                                        sV = "0"
                                    }
                                },
                                sO = "oBookLejl.oWebMainPanel.oBookOversigt"
                            }
                        },*/
                        sFocus = "oBookLejl.oWebMainPanel.oLejlCmb"
                    }
                }
            };
        }

        public GenericReqeustModel CreateFinalBookingRequestModel(List<RequestResponseModels.Addodef> addodef)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>(),
                            sAction = "OnClick",
                            sTarget = "oNyBooking.oBottomPanel.oOkButton"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = addodef,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>
                        {
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psRowID",
                                        sV = "613a0000"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psAndel",
                                        sV = "071"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbCanceled",
                                        sV = "1"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psReturnObject",
                                        sV = "oBookLejl.oWebMainPanel.oBookOversigt"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psInvokingView",
                                        sV = "oBookLejl"
                                    },
                                },
                                sO = "oNyBooking"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "071"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oAndelFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "1"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    }
                                },
                                sO = "oNyBooking.oMainPanel.oAntalUger"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "Leif & Henny"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oNavneFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "+45 4034 3957 / +45 2538 5578"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oTlfFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oAntalV"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022-08-20"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oDatoAnk"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022-08-27"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "1"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oDatoAfg"
                            }
                        },
                        sFocus = "oNyBooking.oBottomPanel.oOkButton"
                    }
                }
            };
        }


        public GenericReqeustModel CreateConfirmBookingRequestModel(List<RequestResponseModels.Addodef> addoFinalStep)
        {
            return new GenericReqeustModel
            {
                ActionRequest = new GenericReqeustModel.Actionrequest
                {
                    aActions = new List<GenericReqeustModel.Actionrequest.Aaction>
                    {
                        new GenericReqeustModel.Actionrequest.Aaction
                        {
                            aParams = new List<string>
                            {
                                "1"
                            },
                            sAction = "DONEWBOOKING",
                            sTarget = "oNyBooking.oBottomPanel.oOkButton"
                        }
                    },
                    Header = new GenericReqeustModel.Actionrequest.HeaderModel
                    {
                        aDDODefs = addoFinalStep,
                        aSyncProps = new List<RequestResponseModels.Asyncprop>
                        {
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psRowID",
                                        sV = "613a0000"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psAndel",
                                        sV = "071"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbCanceled",
                                        sV = "1"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psReturnObject",
                                        sV = "oBookLejl.oWebMainPanel.oBookOversigt"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psInvokingView",
                                        sV = "oBookLejl"
                                    },
                                },
                                sO = "oNyBooking"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "071"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oAndelFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "1"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    }
                                },
                                sO = "oNyBooking.oMainPanel.oAntalUger"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "Leif & Henny"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oNavneFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "+45 4034 3957 / +45 2538 5578"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oTlfFrm"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oAntalV"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022-08-20"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oDatoAnk"
                            },
                            new RequestResponseModels.Asyncprop
                            {
                                aP = new List<RequestResponseModels.Asyncprop.Ap>
                                {
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "psValue",
                                        sV = "2022-08-27"
                                    },
                                    new RequestResponseModels.Asyncprop.Ap
                                    {
                                        sN = "pbChanged",
                                        sV = "0"
                                    },
                                },
                                sO = "oNyBooking.oMainPanel.oDatoAfg"
                            }
                        },
                        sFocus = ""
                    }
                }
            };
        }

        #endregion
    }
}