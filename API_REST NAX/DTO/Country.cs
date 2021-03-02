using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Country
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Id { get; set; } // ID

		[JsonProperty(PropertyName = "nom", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; } // NOMPAIS
		[JsonProperty(PropertyName = "codi_pais", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdCountry { get; set; } //CODPAIS
		[JsonProperty(PropertyName = "codi_ban", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdBan { get; set; } // CODIBAN

		[JsonProperty(PropertyName = "codi_iso3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdIso3 { get; set; } // CODISO3166A3

		public Country()
		{
		}
	}
}