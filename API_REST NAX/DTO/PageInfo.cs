using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class PageInfo
	{
		
		[JsonProperty("resultats_pagina")]
		public int ResultsPage { get; set; }
		[JsonProperty(PropertyName = "total_resultats", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int TotalResults { get; set; }

		public PageInfo()
		{
		}
	}
}