using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using a3ERPActiveX;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    public class BaseController : ApiController
    {
        protected Maestro maestro = null;
        protected Enlace enlace = null;
        protected HttpResponseMessage CreateOkResponse(Object Object)
        {
            Response response = new Response();
            response.Type = "OK";
            if (Object != null)
            {
                response.ObjectResponse = Object;
            }
            Type type = Object.GetType();
            if (type.FullName == "System.Collections.ArrayList")
            {
                PageInfo InfoPage = new PageInfo();
                InfoPage.ResultsPage = ((ArrayList)Object).Count;
                InfoPage.TotalResults = ((ArrayList)Object).Count;
                response.InfoPage = InfoPage;

            }
            return Request.CreateResponse<Response>(System.Net.HttpStatusCode.OK, response);
        }

        protected HttpResponseMessage CreateNotFoundResponse(Object Object) //, String Message)
        {
            Response response = new Response();
            response.Type = "KO";
            response.Message = "No s'ha trobat";
            if (Object != null)
            {
                response.ObjectResponse = Object;
            }
            return Request.CreateResponse<Response>(System.Net.HttpStatusCode.NotFound, response);
        }

        protected HttpResponseMessage CreateBadRequest(Object Object, String Message)
        {
            Response response = new Response();
            response.Type = "KO";
            response.ObjectResponse = Object;
            response.Message = Message;
            return Request.CreateResponse<Response>(System.Net.HttpStatusCode.BadRequest, response);
        }

        protected HttpResponseMessage CreateConflictRequest(Object Object, String Message)
        {
            Response response = new Response();
            response.Type = "KO";
            response.ObjectResponse = Object;
            response.Message = Message;
            return Request.CreateResponse<Response>(System.Net.HttpStatusCode.Conflict, response);
        }

        protected HttpResponseMessage CreateInternalServerErrorRequest(Object Object, String Message)
        {
            Response response = new Response();
            response.Type = "KO";
            response.ObjectResponse = Object;
            response.Message = Message;
            return Request.CreateResponse<Response>(System.Net.HttpStatusCode.InternalServerError, response);
        }
        protected string GetStringField(String field)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                return maestro.AsString[field]?.Trim();
            }
            else
            {
                return "";
            }
        }

        protected double GetFloatField(String field)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                return maestro.AsFloat[field];
            }
            else
            {
                return new Double();
            }
        }

        protected int GetIntegerField(String field)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                return maestro.AsInteger[field];
            }
            else
            {
                return 0;
            }
        }

        protected void PopulateStringFieldIfExists(String field, String value)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                maestro.AsString[field] = value;
            }
        }

        protected void PopulateIntegerFieldIfExists(String field, int value)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                maestro.AsInteger[field] = value;
            }
        }
        protected void PopulateFloatFieldIfExists(String field, double value)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                maestro.AsFloat[field] = value;
            }
        }

        protected void PopulateBooleanFieldIfExists(String field, bool value)
        {
            if (maestro != null && maestro.ExisteCampo(field))
            {
                maestro.AsBoolean[field] = value;
            }
        }

        protected void OpenLink()
        {
            if (enlace == null)
            {
                enlace = new Enlace
                {
                    RaiseOnException = true,
                    VerBarraDeProgreso = false,
                };
                enlace.LoginUsuario("sa", "nexus");
                enlace.Iniciar("bicicletas");
            }
        }

        protected void CloseLink()
        {
            if (enlace != null)
            {
                enlace.Acabar();
            }
        }

        protected void OpenMaster(String name)
        {
            maestro = new Maestro();
            maestro.Iniciar(name);
        }

        protected void CloseMaster()
        {
            if (maestro != null)
            {
                maestro.Acabar();
            }
        }

        protected void CloseMasterLink()
        {
            CloseMaster();
            CloseLink();
        }
    }
}
