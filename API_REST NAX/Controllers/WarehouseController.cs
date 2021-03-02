using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de magatzems amb A3ERP
    /// </summary>
    public class WarehouseController : BaseController
    {
        private readonly String MasterName = "Almacenes";
        /// <summary>
        /// Obtenir tots els magatzems
        /// </summary>
        /// <returns>Llistat de magatzems</returns>
        // GET api/warehouse
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList warehouses = new ArrayList();
            while (!maestro.EOF)
            {
                warehouses.Add(PopulateWarehouse());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(warehouses);
        }

        /// <summary>
        /// Obtenir un magatzem
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Magatzem</returns>
        // GET api/warehouse/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Warehouse warehouse = new Warehouse
            {
                Id = id
            };

            if (maestro.Buscar(warehouse.Id))
            {
                warehouse = PopulateWarehouse();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(warehouse);
            }
            CloseMasterLink();

            return CreateOkResponse(warehouse);
        }

        /// <summary>
        ///  Afegir un magatzem
        /// </summary>
        /// <param name="warehouse"></param>
        // POST api/warehouse
        public HttpResponseMessage Post([FromBody]Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return CreateBadRequest(warehouse, "No ha indicat un magatzem a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (warehouse.Id is null)
            {
                warehouse.Id = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(warehouse.Id))
            {
                return CreateConflictRequest(warehouse, "Vol afegir un magatzem amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(warehouse, warehouse.Id);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(warehouse, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(warehouse);
        }

        /// <summary>
        /// Modificar un magatzem
        /// </summary>
        /// <param name="id">Identificador de la provincia</param>
        /// <param name="warehouse">Magatzem</param>
        /// <returns></returns>
        // PUT api/client/5
        public HttpResponseMessage Put(string id, [FromBody]Warehouse warehouse)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(warehouse, id);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(warehouse, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(warehouse);
            }

            CloseMasterLink();
            return CreateOkResponse(warehouse);
        }

        /// <summary>
        /// Esborrar un magatzem
        /// </summary>
        /// <param name="id">Identificador del magatzem</param>
        /// <returns></returns>
        // DELETE api/warehouse/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Warehouse warehouse = new Warehouse
            {
                Id = id
            };

            OpenMaster(MasterName);
            if (maestro.Buscar(warehouse.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(warehouse);
            }
            CloseMasterLink();
            return CreateOkResponse(warehouse);
        }
    
        private Warehouse PopulateWarehouse()
        {
            Warehouse warehouse = new Warehouse
            {
                Id = GetStringField("CODALM"),
                Country = GetStringField("CODPAIS"),
                IdProvince = GetStringField("CODPROVI"),
                Description = GetStringField("DESCALM"),
                Address = GetStringField("DIRALM"),
                PostalCode = GetStringField("DTOALM"),
                Email = GetStringField("E_MAIL"),
                InCharge = GetStringField("ENCARGADO"),
                Fax = GetStringField("FAXALM"),
                Observations = GetStringField("OBSALM"),
                Town = GetStringField("POBALM"),
                Telephone = GetStringField("TELALM"),
                Telephone2 = GetStringField("TEL2ALM")
            };

            return warehouse;
        }

        private void PopulateMaster(Warehouse warehouse, String id)
        {
            // PopulateStringFieldIfExists("CODALM", id);
            
            PopulateStringFieldIfExists("CODPAIS", warehouse.Country);
            PopulateStringFieldIfExists("CODPROVI", warehouse.IdProvince);
            PopulateStringFieldIfExists("DESCALM", warehouse.Description);
            PopulateStringFieldIfExists("DIRALM", warehouse.Address);
            PopulateStringFieldIfExists("DTOALM", warehouse.PostalCode);
            PopulateStringFieldIfExists("E_MAIL", warehouse.Email);
            PopulateStringFieldIfExists("ENCARGADO", warehouse.InCharge);
            PopulateStringFieldIfExists("FAXALM", warehouse.Fax);
            PopulateStringFieldIfExists("OBSALM", warehouse.Observations);
            PopulateStringFieldIfExists("POBALM", warehouse.Town);
            PopulateStringFieldIfExists("TELALM", warehouse.Telephone);
            PopulateStringFieldIfExists("TEL2ALM", warehouse.Telephone2);
        }
    }
}
