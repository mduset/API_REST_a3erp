using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Supplier
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Id { get; set; } // CODPRO

		[JsonProperty(PropertyName = "organitzacio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IdOrg { get; set; } // IDORG

		[JsonProperty(PropertyName = "car1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Car1 { get; set; } //CAR1
		[JsonProperty(PropertyName = "car2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Car2 { get; set; } //CAR2

		[JsonProperty(PropertyName = "car3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Car3 { get; set; } //CAR3

		[JsonProperty(PropertyName = "idioma", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Language { get; set; } // CODIDIOMA

		[JsonProperty(PropertyName = "moneda", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Coin { get; set; } // CODMON

		[JsonProperty(PropertyName = "compte", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Account { get; set; } // CUENTA

		[JsonProperty(PropertyName = "desc1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc1 { get; set; } // DESC1
		[JsonProperty(PropertyName = "desc2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc2 { get; set; } // DESC2
		[JsonProperty(PropertyName = "desc3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc3 { get; set; } // DESC3
		[JsonProperty(PropertyName = "desc4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Desc4 { get; set; } // DESC4

		[JsonProperty(PropertyName = "format_enviament", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ShippingFormat { get; set; } // FORMATOENVIO

		[JsonProperty(PropertyName = "observaciones", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Observations { get; set; } // OBSPRO

		[JsonProperty(PropertyName = "param1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param1 { get; set; } // PARAM1
		[JsonProperty(PropertyName = "param2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param2 { get; set; } // PARAM2
		[JsonProperty(PropertyName = "param3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param3 { get; set; } // PARAM3
		[JsonProperty(PropertyName = "param4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param4 { get; set; } // PARAM4
		[JsonProperty(PropertyName = "param5", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param5 { get; set; } // PARAM5
		[JsonProperty(PropertyName = "param6", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param6 { get; set; } // PARAM6
		[JsonProperty(PropertyName = "param7", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param7 { get; set; } // PARAM7
		[JsonProperty(PropertyName = "param8", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param8 { get; set; } // PARAM8
		[JsonProperty(PropertyName = "param9", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Param9 { get; set; } // PARAM9
		[JsonProperty(PropertyName = "ref_client", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerReference { get; set; } // REFCLI
		[JsonProperty(PropertyName = "tipus_iva", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TypeIVA { get; set; } // TIPIVA

		[JsonProperty(PropertyName = "tipus_empesa", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CompanyType { get; set; } // TIPOEMPRESA
		[JsonProperty(PropertyName = "tipus_irpf", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IRPFType { get; set; } // TIPOIRPF 

		[JsonProperty(PropertyName = "tipus_registre", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RecordType { get; set; } // TIPOREGISTRO

		[JsonProperty(PropertyName = "tipus_risc", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RiskType { get; set; } // TIPRIESGO

		[JsonProperty(PropertyName = "tpv_tactil", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string TPVTactil { get; set; } // TPVTACTIL

		[JsonProperty(PropertyName = "centre_cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CostCenter { get; set; }// CENTROCOSTE

		[JsonProperty(PropertyName = "centre_cost2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CostCenter2 { get; set; }// CENTROCOSTE2
		[JsonProperty(PropertyName = "centre_cost3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CostCenter3 { get; set; }// CENTROCOSTE3

		public Supplier()
		{
		}
	}
}