using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Client
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Id { get; set; }
		[JsonProperty(PropertyName = "nom", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; } // CONTACTO
		[JsonProperty(PropertyName = "dni", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Dni { get; set; }
		[JsonProperty(PropertyName = "carrer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Street { get; set; }
		[JsonProperty(PropertyName = "codiPostal", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PostalCode { get; set; }
		[JsonProperty(PropertyName = "codiProvincia", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProvinceCode { get; set; }
		[JsonProperty(PropertyName = "ciutat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string City { get; set; }
		[JsonProperty(PropertyName = "pais", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Country { get; set; }
		[JsonProperty(PropertyName = "correu", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Mail { get; set; } // E_MAIL_DOCS
		[JsonProperty(PropertyName = "web", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Webpage { get; set; }
		[JsonProperty(PropertyName = "telefon", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Telephone { get; set; }
		[JsonProperty(PropertyName = "llengua", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Language { get; set; } // CODIDIOMA
		[JsonProperty(PropertyName = "moneda", DefaultValueHandling = DefaultValueHandling.Ignore)] 
		public string Coin { get; set; } // CODMON
		[JsonProperty(PropertyName = "organitzacio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IdOrg { get; set; } // IDORG
		[JsonProperty(PropertyName = "usuari", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string User { get; set; }// USUARIO

		public Client()
		{
		}

		public override string ToString()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();

			builder.Append("Id: ").Append(Id).Append(Environment.NewLine);
			builder.Append("Name: ").Append(Name).Append(Environment.NewLine);
			builder.Append("Dni: ").Append(Dni).Append(Environment.NewLine);
			builder.Append("Street: ").Append(Street).Append(Environment.NewLine);
			builder.Append("PostalCode: ").Append(PostalCode).Append(Environment.NewLine);
			builder.Append("City: ").Append(City).Append(Environment.NewLine);
			builder.Append("Country: ").Append(Country).Append(Environment.NewLine);
			builder.Append("ProvinceCode: ").Append(ProvinceCode).Append(Environment.NewLine);
			builder.Append("Mail: ").Append(Mail).Append(Environment.NewLine);
			builder.Append("Webpage: ").Append(Webpage).Append(Environment.NewLine);
			builder.Append("Telephone: ").Append(Telephone).Append(Environment.NewLine);

			return builder.ToString();
		}
	}
}