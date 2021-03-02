using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Response
	{
		
		[JsonProperty("tipus")]
		public string Type { get; set; }
		[JsonProperty(PropertyName = "missatge", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Message { get; set; }
		[JsonProperty(PropertyName = "resposta", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Object ObjectResponse { get; set; }
		[JsonProperty(PropertyName = "info_pagina", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PageInfo InfoPage { get; set; }

		public Response()
		{
		}

		public override string ToString()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();

			builder.Append("Type: ").Append(Type).Append(Environment.NewLine);
			builder.Append("Message: ").Append(Message).Append(Environment.NewLine);
			builder.Append("ObjectResponse: ").Append(ObjectResponse).Append(Environment.NewLine);

			return builder.ToString();
		}
	}
}