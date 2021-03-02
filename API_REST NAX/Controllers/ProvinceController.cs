using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de Provincies amb A3ERP
    /// </summary>
    public class ProvinceController : BaseController
    {
        private readonly String MasterName = "Provinci";
        /// <summary>
        /// Obtenir totes les provincies
        /// </summary>
        /// <returns>Llistat de provincies</returns>
        // GET api/province
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList provinces = new ArrayList();
            while (!maestro.EOF)
            {
                provinces.Add(PopulateProvince());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(provinces);
        }

        /// <summary>
        /// Obtenir una provincia
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Provincia</returns>
        // GET api/province/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Province province = new Province
            {
                IdProvince = id
            };

            if (maestro.Buscar(province.IdProvince))
            {
                province = PopulateProvince();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(province);
            }
            CloseMasterLink();

            return CreateOkResponse(province);
        }

        /// <summary>
        ///  Afegir una provincia
        /// </summary>
        /// <param name="province"></param>
        // POST api/province
        public HttpResponseMessage Post([FromBody]Province province)
        {
            if (province == null)
            {
                return CreateBadRequest(province, "No ha indicat una provincia a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (province.IdProvince is null)
            {
                province.IdProvince = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(province.IdProvince))
            {
                return CreateConflictRequest(province, "Vol afegir una provincia amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(province, province.IdProvince);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(province, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(province);
        }

        /// <summary>
        /// Modificar una provincia
        /// </summary>
        /// <param name="id">Identificador de la provincia</param>
        /// <param name="province">Provincia</param>
        /// <returns></returns>
        // PUT api/client/5
        public HttpResponseMessage Put(string id, [FromBody]Province province)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(province, id);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(province, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(province);
            }

            CloseMasterLink();
            return CreateOkResponse(province);
        }

        /// <summary>
        /// Esborrar una provincia
        /// </summary>
        /// <param name="id">Identificador de la provincia</param>
        /// <returns></returns>
        // DELETE api/province/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Province province = new Province
            {
                IdProvince = id
            };

            OpenMaster(MasterName);
            if (maestro.Buscar(province.IdProvince))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(province);
            }
            CloseMasterLink();
            return CreateOkResponse(province);
        }
    
        private Province PopulateProvince()
        {
            Province province = new Province();

            province.Id = GetIntegerField("ID");
            province.Name = GetStringField("NOMPROVI");
            province.IdProvince = GetStringField("CODPROVI");
            province.CodCounty = GetStringField("CODCOM");

            return province;
        }

        private void PopulateMaster(Province province, String id)
        {
            PopulateIntegerFieldIfExists("ID", province.Id);
            PopulateStringFieldIfExists("NOMPROVI", province.Name);
            PopulateStringFieldIfExists("CODPROVI", id);
            PopulateStringFieldIfExists("CODCOM", province.CodCounty);
        }
    }
}
