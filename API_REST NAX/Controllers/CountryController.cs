using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de Paisos amb A3ERP
    /// </summary>
    public class CountryController : BaseController
    {
        private readonly String MasterName = "Paises";
        /// <summary>
        /// Obtenir tots els paisos
        /// </summary>
        /// <returns>Llistat de paisos</returns>
        // GET api/client
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList countries = new ArrayList();
            while (!maestro.EOF)
            {
                countries.Add(PopulateCountry());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(countries);
        }

        /// <summary>
        /// Obtenir un pais
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pais</returns>
        // GET api/client/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Country country = new Country();
            country.IdCountry = id;

            if (maestro.Buscar(country.IdCountry))
            {
                country = PopulateCountry();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(country);
            }
            CloseMasterLink();

            return CreateOkResponse(country);
        }

        /// <summary>
        ///  Afegir un pais
        /// </summary>
        /// <param name="country">Pais</param>
        /// <returns></returns>
        // POST api/client
        public HttpResponseMessage Post([FromBody]Country country)
        {
            if (country == null)
            {
                return CreateBadRequest(country, "No ha indicat un pais a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (country.Id is null)
            {
                country.Id = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(country.Id))
            {
                return CreateConflictRequest(country, "Vol afegir un pais amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(country);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(country, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(country);
        }

        /// <summary>
        ///  Modificar un pais
        /// </summary>
        /// <param name="id"> Id del pais a modificar</param>
        /// <param name="country">Pais a modificar</param>
        /// <returns></returns>
        // PUT api/country/5
        public HttpResponseMessage Put(string id, [FromBody]Country country)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(country);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(country, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(country);
            }

            CloseMasterLink();
            return CreateOkResponse(country);
        }

        /// <summary>
        /// Esborrar un pais
        /// </summary>
        /// <param name="id">Identificador del pais</param>
        /// <returns></returns>
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Country country = new Country
            {
                Id = id
            };

            OpenMaster(MasterName);
            if (maestro.Buscar(country.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(country);
            }
            CloseMasterLink();
            return CreateOkResponse(country);
        }
    
        private Country PopulateCountry()
        {
            Country country = new Country
            {
                Name = GetStringField("NOMPAIS"),
                IdCountry = GetStringField("CODPAIS"),
                IdBan = GetStringField("CODIBAN"),
                IdIso3 = GetStringField("CODISO3166A3"),
                Id = GetStringField("ID")
            };

            return country;
        }

        private void PopulateMaster(Country country)
        {
            PopulateStringFieldIfExists("NOMPAIS", country.Name);
            PopulateStringFieldIfExists("CODIBAN", country.IdBan);
        }
    }
}
