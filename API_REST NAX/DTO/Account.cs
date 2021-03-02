using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Account
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Id { get; set; } // IDCUENTA
		[JsonProperty(PropertyName = "admet_monedes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SupportCoin { get; set; } // ADMITEMONEDAS
		[JsonProperty(PropertyName = "compte", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Account_ { get; set; } //CUENTA
		[JsonProperty(PropertyName = "descripcio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; } // DESCCUE
		[JsonProperty(PropertyName = "detall", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Detail { get; set; } // DETALLE
		[JsonProperty(PropertyName = "nbsa", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NBSA { get; set; } //NBSA
		[JsonProperty(PropertyName = "nbsap", DefaultValueHandling = DefaultValueHandling.Ignore)] 
		public string NBSAP { get; set; } //NBSAP
		[JsonProperty(PropertyName = "nbsn", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NBSN { get; set; } //NBSN
		[JsonProperty(PropertyName = "nbsnp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NBSNP { get; set; } //NBSNP
		[JsonProperty(PropertyName = "nbsp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NBSP { get; set; } //NBSP
		[JsonProperty(PropertyName = "nbspp", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NBSPP { get; set; } //NBSPP
		[JsonProperty(PropertyName = "nivell", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Level { get; set; } // NIVEL

		public Account()
		{
		}
	}
}