using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de Clients amb A3ERP
    /// </summary>
    public class ClientController : BaseController
    {
        private readonly String MasterName = "Clientes";
        /// <summary>
        /// Obtenir tots els clients
        /// </summary>
        /// <returns>Llistat de clients</returns>
        // GET api/client
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList clients = new ArrayList();
            while (!maestro.EOF)
            {
                clients.Add(PopulateClient());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(clients);
        }

        /// <summary>
        /// Obtenir un client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client</returns>
        // GET api/client/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Client client = new Client
            {
                Id = id
            };

            if (maestro.Buscar(client.Id))
            {
                client = PopulateClient();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(client);
            }
            CloseMasterLink();

            return CreateOkResponse(client);
        }

        /// <summary>
        ///  Afegir un client
        /// </summary>
        /// <param name="client"></param>
        // POST api/client
        public HttpResponseMessage Post([FromBody]Client client)
        {
            if (client == null)
            {
                return CreateBadRequest(client, "No ha indicat un client a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (client.Id is null)
            {
                client.Id = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(client.Id))
            {
                return CreateConflictRequest(client, "Vol afegir un client amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(client, client.Id);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(client, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(client);
        }

        /// <summary>
        /// Modificar un client
        /// </summary>
        /// <param name="id">Identificador del client</param>
        /// <param name="client">Client</param>
        /// <returns></returns>
        // PUT api/client/5
        public HttpResponseMessage Put(string id, [FromBody]Client client)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(client, id);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(client, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(client);
            }

            CloseMasterLink();
            return CreateOkResponse(client);
        }

        /// <summary>
        /// Esborrar un client
        /// </summary>
        /// <param name="id">Identificador del client</param>
        /// <returns></returns>
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Client client = new Client();
            client.Id = id;

            OpenMaster(MasterName);
            if (maestro.Buscar(client.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(client);
            }
            CloseMasterLink();
            return CreateOkResponse(client);
        }
    
        private Client PopulateClient()
        {
            Client client = new Client();

            client.City = GetStringField("CODPAIS");
            client.ProvinceCode = GetStringField("CODPROVI");
            client.Name = GetStringField("CONTACTO");
            client.PostalCode = GetStringField("DTOFISCAL");
            client.Country = GetStringField("CODPAIS");
            client.Webpage = GetStringField("PAGINAWEB");
            client.Id = GetStringField("CodCli");
            client.Mail = GetStringField("E_MAIL_DOCS");
            client.IdOrg = GetIntegerField("IDORG");
            client.User = GetStringField("USUARIO");

            return client;
        }

        private void PopulateMaster(Client client, String id)
        {
            PopulateStringFieldIfExists("CONTACTO", client.Name);
            PopulateStringFieldIfExists("E_MAIL_DOCS", client.Mail);
            PopulateStringFieldIfExists("CODPAIS", client.Country);
            PopulateStringFieldIfExists("DIRFISCAL", client.Street);

            PopulateStringFieldIfExists("DTOFISCAL", client.PostalCode);
            PopulateStringFieldIfExists("E_MAIL", client.Mail);
            PopulateStringFieldIfExists("EMAILFISCAL", client.Mail);
            PopulateStringFieldIfExists("CONTACTO", client.Name);

            PopulateStringFieldIfExists("PAGINAWEB", client.Webpage);
            PopulateStringFieldIfExists("POBFISCAL", client.City);
            PopulateStringFieldIfExists("USUARIO", client.User);
            PopulateIntegerFieldIfExists("IDORG", client.IdOrg);

            PopulateStringFieldIfExists("NOMBRE", client.Name);

            PopulateBooleanFieldIfExists("ENLAZADOA3ASESOR", false);
            PopulateStringFieldIfExists("CodCli", id);
        }
    }
}
