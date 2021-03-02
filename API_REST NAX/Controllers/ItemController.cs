using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió d'articles amb A3ERP
    /// </summary>
    public class ItemController : BaseController
    {
        private readonly String MasterName = "Articulos";
        /// <summary>
        /// Obtenir tots els articles
        /// </summary>
        /// <returns>Llistat d'articles</returns>
        // GET api/item
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList items = new ArrayList();
            while (!maestro.EOF)
            {
                items.Add(PopulateItem());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(items);
        }

        /// <summary>
        /// Obtenir un article
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client</returns>
        // GET api/item/35
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            Item item = new Item();
            item.ArticleCode = id;

            OpenMaster(MasterName);

            if (maestro.Buscar(item.ArticleCode))
            {
                item = PopulateItem();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(item);
                //return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            CloseMasterLink();
            return CreateOkResponse(item);
            //return Request.CreateResponse<Item>(System.Net.HttpStatusCode.OK, item);
        }

        /// <summary>
        /// Afegir un article
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST api/client
        public HttpResponseMessage Post([FromBody]Item item)
        {
            if (item == null)
            {
                return CreateBadRequest(item, "No s'ha indicat cap article");
                //return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
            OpenLink();
            OpenMaster(MasterName);

            if (item.ArticleCode is null)
            {
                item.ArticleCode = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(item.ArticleCode))
            {
                CloseMasterLink();
                return CreateConflictRequest(item, "Ja existeix un article amb aquest id");
            }

            try
            {
                maestro.Nuevo();
                PopulateStringFieldIfExists("DescArt", item.Name);
                PopulateStringFieldIfExists("CodArt", item.ArticleCode);

                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(item, e.Message);
                //return Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(item);
            //return Request.CreateResponse(System.Net.HttpStatusCode.Created);

        }

        /// <summary>
        /// Modificar un article
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT api/item/5
        public HttpResponseMessage Put(string id, [FromBody]Item item)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateStringFieldIfExists("DescArt", item.Name);
                    PopulateStringFieldIfExists("CodArt", id);

                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(item, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(item);
            }

            CloseMasterLink();
            return CreateOkResponse(item);
        }

        /// <summary>
        /// Esborrar un article
        /// </summary>
        /// <param name="id">Identificador de l'article</param>
        /// <returns></returns>
        // DELETE api/item/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Item item = new Item();
            item.ArticleCode = id;

            OpenMaster(MasterName);
            if (maestro.Buscar(item.ArticleCode))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(item);
            }

            CloseMasterLink();
            return CreateOkResponse(item);
        }

        private Item PopulateItem()
        {
            Item item = new Item();

            item.Name = GetStringField("DescArt");
            item.ArticleCode = GetStringField("CodArt");

            item.Nickname = GetStringField("ARTALIAS");

            item.Production = GetStringField("ARTPRO");
            item.Desc1 = GetFloatField("DESC1");
            item.Desc2 = GetFloatField("DESC2");
            item.Desc3 = GetFloatField("DESC3");
            item.Desc4 = GetFloatField("DESC4");

            item.ShortDescription = GetStringField("DESCCORTA");
            item.LongDescription = GetStringField("DESCLARGA");
            item.DescMax = GetFloatField("DESCMAX");

            item.VolumeMeasure = GetStringField("MEDIDAVOLUMEN");
            item.MeasureWeight = GetStringField("MEDIDAPESO");

            item.Weight = GetFloatField("PESO");
            item.PurchasePrice = GetFloatField("PRCCOMPRA");

            item.CostPrice = GetFloatField("PRCCOSTE");
            item.ManufacturingPrice = GetFloatField("PRCFABRICACION");
            item.MinimalPrice = GetFloatField("PRCMINIMO");

            item.StandardPrice = GetFloatField("PRCSTANDARD");
            item.SalePrice = GetFloatField("PRCVENTA");
            item.TypeIVA = GetStringField("TIPIVA");
            item.UnitType = GetStringField("TIPOUNIDAD");

            return item;
        }
    }
}
