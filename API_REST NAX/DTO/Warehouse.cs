using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Warehouse
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public String Id { get; set; } // CODALM

		[JsonProperty(PropertyName = "pais", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Country { get; set; } // CODPAIS

		[JsonProperty(PropertyName = "id_provincia", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdProvince { get; set; } // CODPROVI

		[JsonProperty(PropertyName = "descripcio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; } // DESCALM

		[JsonProperty(PropertyName = "direccio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; } // DIRALM

		[JsonProperty(PropertyName = "codi_postal", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PostalCode { get; set; }// DTOALM

		[JsonProperty(PropertyName = "correu", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; } // E_MAIL

		[JsonProperty(PropertyName = "encarregat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string InCharge { get; set; } //ENCARGADO

		[JsonProperty(PropertyName = "fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; } //FAXALM

		[JsonProperty(PropertyName = "observacions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Observations { get; set; } //OBSALM

		[JsonProperty(PropertyName = "poblacio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Town { get; set; } // POBALM

		[JsonProperty(PropertyName = "telefon", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Telephone { get; set; } // TELALM

		[JsonProperty(PropertyName = "telefon2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Telephone2 { get; set; } // TEL2ALM

		public Warehouse()
		{
		}
	}
}