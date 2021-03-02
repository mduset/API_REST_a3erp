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
    public class SupplierController : BaseController
    {
        private readonly String MasterName = "Proveedores";
        /// <summary>
        /// Obtenir tots els proveïdors
        /// </summary>
        /// <returns>Llistat de proveïdors</returns>
        // GET api/client
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList suppliers = new ArrayList();
            while (!maestro.EOF)
            {
                suppliers.Add(PopulateSupplier());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(suppliers);
        }

        /// <summary>
        /// Obtenir un proveïdor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Proveïdor</returns>
        // GET api/supplier/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Supplier supplier = new Supplier();
            supplier.Id = id;

            if (maestro.Buscar(supplier.Id))
            {
                supplier = PopulateSupplier();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(supplier);
            }
            CloseMasterLink();

            return CreateOkResponse(supplier);
        }

        /// <summary>
        ///  Afegir un proveïdor
        /// </summary>
        /// <param name="value"></param>
        // POST api/supplier
        public HttpResponseMessage Post([FromBody]Supplier supplier)
        {
            if (supplier == null)
            {
                return CreateBadRequest(supplier, "No ha indicat un proveïdor a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (supplier.Id is null)
            {
                supplier.Id = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(supplier.Id))
            {
                return CreateConflictRequest(supplier, "Vol afegir un proveïdor amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(supplier, supplier.Id);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(supplier, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(supplier);
        }


        /// <summary>
        /// Modificar un proveïdor
        /// </summary>
        /// <param name="id">Identificador del proveïdor</param>
        /// <param name="supplier">Proveïdor</param>
        /// <returns></returns>
        // PUT api/supplier/5
        public HttpResponseMessage Put(string id, [FromBody]Supplier supplier)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Nuevo();
                    PopulateMaster(supplier, id);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(supplier, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(supplier);
            }

            CloseMasterLink();
            return CreateOkResponse(supplier);
        }

        /// <summary>
        /// Esborrar un proveïdor
        /// </summary>
        /// <param name="id">Identificador del proveïdor</param>
        /// <returns></returns>
        // DELETE api/supplier/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Supplier supplier = new Supplier();
            supplier.Id = id;

            OpenMaster(MasterName);
            if (maestro.Buscar(supplier.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(supplier);
            }
            CloseMasterLink();
            return CreateOkResponse(supplier);
        }

        private Supplier PopulateSupplier()
        {
            Supplier supplier = new Supplier();

            supplier.Id = GetStringField("CODPRO");
            supplier.IdOrg = GetIntegerField("IDORG");
            supplier.Car1 = GetStringField("CAR1");
            supplier.Car2 = GetStringField("CAR2");
            supplier.Car3 = GetStringField("CAR3");
            supplier.Language = GetStringField("CODIDIOMA");
            supplier.Coin = GetStringField("CODMON");
            supplier.Desc1 = GetFloatField("DESC1");
            supplier.Desc2 = GetFloatField("DESC2");
            supplier.Desc3 = GetFloatField("DESC3");
            supplier.Desc4 = GetFloatField("DESC4");
            supplier.ShippingFormat = GetStringField("FORMATOENVIO");
            supplier.Observations = GetStringField("OBSPRO");
            supplier.Param1 = GetStringField("PARAM1");
            supplier.Param2 = GetStringField("PARAM2");
            supplier.Param3 = GetStringField("PARAM3");
            supplier.Param4 = GetStringField("PARAM4");
            supplier.Param5 = GetStringField("PARAM5");
            supplier.Param6 = GetStringField("PARAM6");
            supplier.Param7 = GetStringField("PARAM7");
            supplier.Param8 = GetStringField("PARAM8");
            supplier.Param9 = GetStringField("PARAM9");
            supplier.CustomerReference = GetStringField("REFCLI");
            supplier.TypeIVA = GetStringField("TIPIVA");
            supplier.CompanyType = GetStringField("TIPOEMPRESA");
            supplier.IRPFType = GetStringField("TIPOIRPF");
            supplier.RecordType = GetStringField("TIPOREGISTRO");
            supplier.RiskType = GetStringField("TIPRIESGO");
            supplier.TPVTactil = GetStringField("TPVTACTIL");
            supplier.CostCenter = GetStringField("CENTROCOSTE");
            supplier.CostCenter2 = GetStringField("CENTROCOSTE2");
            supplier.CostCenter3 = GetStringField("CENTROCOSTE3");

            return supplier;
        }

        private void PopulateMaster(Supplier supplier, String id)
        {
            PopulateStringFieldIfExists("CODPRO", supplier.Id);
            PopulateIntegerFieldIfExists("IDORG", supplier.IdOrg);
            PopulateStringFieldIfExists("CAR1", supplier.Car1);
            PopulateStringFieldIfExists("CAR2", supplier.Car2);
            PopulateStringFieldIfExists("CAR3", supplier.Car3);
            PopulateStringFieldIfExists("CODIDIOMA", supplier.Language);
            PopulateStringFieldIfExists("CODMON", supplier.Coin);
            PopulateFloatFieldIfExists("DESC1", supplier.Desc1);
            PopulateFloatFieldIfExists("DESC2", supplier.Desc2);
            PopulateFloatFieldIfExists("DESC3", supplier.Desc3);
            PopulateFloatFieldIfExists("DESC4", supplier.Desc4);
            PopulateStringFieldIfExists("FORMATOENVIO", supplier.ShippingFormat);
            PopulateStringFieldIfExists("OBSPRO", supplier.Observations);
            PopulateStringFieldIfExists("PARAM1", supplier.Param1);
            PopulateStringFieldIfExists("PARAM2", supplier.Param2);
            PopulateStringFieldIfExists("PARAM3", supplier.Param3);
            PopulateStringFieldIfExists("PARAM4", supplier.Param4);
            PopulateStringFieldIfExists("PARAM5", supplier.Param5);
            PopulateStringFieldIfExists("PARAM6", supplier.Param6);
            PopulateStringFieldIfExists("PARAM7", supplier.Param7);
            PopulateStringFieldIfExists("PARAM8", supplier.Param8);
            PopulateStringFieldIfExists("PARAM9", supplier.Param9);
            PopulateStringFieldIfExists("REFCLI", supplier.CustomerReference);
            PopulateStringFieldIfExists("TIPIVA", supplier.TypeIVA);
            PopulateStringFieldIfExists("TIPOEMPRESA", supplier.CompanyType);
            PopulateStringFieldIfExists("TIPOIRPF", supplier.IRPFType);
            PopulateStringFieldIfExists("TIPOREGISTRO", supplier.RecordType);
            PopulateStringFieldIfExists("TIPRIESGO", supplier.RiskType);
            PopulateStringFieldIfExists("TPVTACTIL", supplier.TPVTactil);
            PopulateStringFieldIfExists("CENTROCOSTE", supplier.CostCenter);
            PopulateStringFieldIfExists("CENTROCOSTE2", supplier.CostCenter2);
            PopulateStringFieldIfExists("CENTROCOSTE3", supplier.CostCenter3);
        }
    }
}
