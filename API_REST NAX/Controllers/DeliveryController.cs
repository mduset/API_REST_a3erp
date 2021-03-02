using System;
using System.Net.Http;
using System.Web.Http;
using a3ERPActiveX;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió d'albarans amb A3ERP
    /// </summary>
    public class DeliveryController : BaseController
    {
        private Albaran albaran = null;
        /// <summary>
        ///  Afegir un albarà
        /// </summary>
        /// <param name="delivery"></param>
        // POST api/delivery
        public HttpResponseMessage Post([FromBody]Delivery delivery)
        {
            if (delivery == null)
            {
                return CreateBadRequest(delivery, "No ha indicat un albarà a afegir");
            }
            OpenLink();
            albaran = new Albaran();
            albaran.Iniciar();

            try { 
                albaran.Nuevo(delivery.Date,delivery.CustomerId, false);
                PopulateAlbaran(delivery);

                if (delivery.lines != null && delivery.lines.Count >0)
                {
                    foreach (DeliveryLine line in delivery.lines)
                    {
                        albaran.NuevaLineaArt(line.ItemCode, double.Parse(line.Quantity));
                        albaran.AnadirLinea();
                    }
                }

                albaran.CalcularImpuestosyTotales();
                albaran.Anade();
            } catch ( Exception e)
            {
                albaran.Acabar();
                return CreateInternalServerErrorRequest(delivery, e.Message);
            }
            albaran.Acabar();
            CloseLink();
            return CreateOkResponse(delivery);
        }

        private void PopulateAlbaran(Delivery delivery)
        {
            //albaran.AsStringCab["PARAM1"] = delivery.Param1;
            // albaran.AsStringCab["REFERENCIA"] = delivery.Reference;
        }
    }
}
