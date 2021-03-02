using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class DeliveryLine
	{
		[JsonProperty(PropertyName = "codi_article", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ItemCode { get; set; }
		[JsonProperty(PropertyName = "quantitat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Quantity { get; set; }
		
		//public Array<>

		public DeliveryLine()
		{
		}
	}
}