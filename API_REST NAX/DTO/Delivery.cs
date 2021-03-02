using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_REST_NAX.DTO
{
	public class Delivery
	{
		[JsonProperty(PropertyName = "data", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Date { get; set; }
		[JsonProperty(PropertyName = "codi_client", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomerId { get; set; }
		[JsonProperty(PropertyName = "lineas", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public List<DeliveryLine> lines { get; set; }

		public Delivery()
		{
		}
	}
}