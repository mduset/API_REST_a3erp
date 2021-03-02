using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Item
	{
		[JsonProperty(PropertyName = "nom", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; } // COVIANWANATE
		[JsonProperty(PropertyName = "quantitat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Quantity { get; set; } // 1
		[JsonProperty(PropertyName = "preu", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Price { get; set; } // 552.42
		[JsonProperty(PropertyName = "preuIva", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PriceWithVat { get; set; } // 668.43
		[JsonProperty(PropertyName = "codiArticle", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ArticleCode { get; set; } // Get Article code from database
		[JsonProperty(PropertyName = "alias", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Nickname { get; set; } // ARTALIAS
		[JsonProperty(PropertyName = "produccio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Production { get; set; } // ARTPRO
		[JsonProperty(PropertyName = "descompte1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc1 { get; set; } //DESC1
		[JsonProperty(PropertyName = "descompte2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc2 { get; set; } //DESC2
		[JsonProperty(PropertyName = "descompte3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc3 { get; set; } //DESC3
		[JsonProperty(PropertyName = "descompte4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc4 { get; set; } //DESC4
		[JsonProperty(PropertyName = "descripcio_curta", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ShortDescription { get; set; } // DESCCORTA
		[JsonProperty(PropertyName = "descripcio_llarga", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LongDescription { get; set; } // DESCLARGA
		[JsonProperty(PropertyName = "descompte_maxim", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DescMax { get; set; } //DESCMAX
		[JsonProperty(PropertyName = "mesura_volum", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VolumeMeasure { get; set; } // MEDIDAVOLUMEN
		[JsonProperty(PropertyName = "mesura_pes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MeasureWeight { get; set; } // MEDIDAPESO
		[JsonProperty(PropertyName = "pes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Weight { get; set; } // PESO
		[JsonProperty(PropertyName = "preu_compra", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double PurchasePrice { get; set; } // PRCCOMPRA
		[JsonProperty(PropertyName = "preu_cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double CostPrice { get; set; } // PRCCOSTE
		[JsonProperty(PropertyName = "preu_fabricacio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double ManufacturingPrice { get; set; }// PRCFABRICACION
		[JsonProperty(PropertyName = "preu_minim", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double MinimalPrice { get; set; } // PRCMINIMO
		[JsonProperty(PropertyName = "preu_estandard", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double StandardPrice { get; set; } // PRCSTANDARD
		[JsonProperty(PropertyName = "preu_venta", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double SalePrice { get; set; } // PRCVENTA
		[JsonProperty(PropertyName = "tipus_iva", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TypeIVA { get; set; } // TIPIVA
		[JsonProperty(PropertyName = "tipus_unitat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UnitType { get; set; } // TIPOUNIDAD
		public override String ToString()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();

			builder.Append("Name: ").Append(Name).Append(Environment.NewLine);
			builder.Append("Quantity: ").Append(Quantity).Append(Environment.NewLine);
			builder.Append("Price: ").Append(Price).Append(Environment.NewLine);
			builder.Append("PriceWitVat: ").Append(PriceWithVat).Append(Environment.NewLine);

			return builder.ToString();
		}
	}
}