using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Province
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; } // ID
		[JsonProperty(PropertyName = "nom", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; } // NOMPROVI
		[JsonProperty(PropertyName = "id_provincia", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdProvince { get; set; } // CODPROVI
		[JsonProperty(PropertyName = "codi_comarca", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CodCounty { get; set; } // CODCOM

		public Province()
		{
		}
	}
}