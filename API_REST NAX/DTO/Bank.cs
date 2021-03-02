using Newtonsoft.Json;
using System;

namespace API_REST_NAX.DTO
{
	public class Bank
	{
		[JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public String Id { get; set; } // CODBAN

		[JsonProperty(PropertyName = "ageban", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Ageban { get; set; } // AGEBAN
		[JsonProperty(PropertyName = "agencia", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Agency { get; set; } // AGENCIA
		[JsonProperty(PropertyName = "bic", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string BIC { get; set; } //BIC
		[JsonProperty(PropertyName = "pais", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Country { get; set; } // CODPAIS
		[JsonProperty(PropertyName = "provincia", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Province { get; set; } //CODPRO
		[JsonProperty(PropertyName = "compte_deuda", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DebtAccount { get; set; } // CTADEUDA
		[JsonProperty(PropertyName = "compte", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Account { get; set; } // CUENTA
		[JsonProperty(PropertyName = "digits", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Digit { get; set; } //DIGCONT

		[JsonProperty(PropertyName = "direccio", DefaultValueHandling = DefaultValueHandling.Ignore)] 
		public string Direction { get; set; } //DIRBAN

		[JsonProperty(PropertyName = "codi_postal", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PostalCode { get; set; } //DTOBAN

		[JsonProperty(PropertyName = "correu", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; } //E_MAIL
		[JsonProperty(PropertyName = "fax", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Fax { get; set; } //FAXBAN

		[JsonProperty(PropertyName = "iban", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IBAN { get; set; } //IBAN

		[JsonProperty(PropertyName = "nom", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; } // NOMBAN

		[JsonProperty(PropertyName = "numero_compte", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AccountNumber { get; set; } // NUMCUE

		[JsonProperty(PropertyName = "observacions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Observations { get; set; } // OBSBAN

		[JsonProperty(PropertyName = "web", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Web { get; set; } // PAGINAWEB

		[JsonProperty(PropertyName = "poblacio", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Town { get; set; } // POBBAN

		[JsonProperty(PropertyName = "telefon", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Telephone { get; set; } // TELBAN

		[JsonProperty(PropertyName = "telefon2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Telephone2 { get; set; } // TEL2BAN

		[JsonProperty(PropertyName = "bic_extern", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExternalBIC { get; set; } //BICEXT

		[JsonProperty(PropertyName = "compte_extern", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExternalAccount { get; set; } // CUENTAEXT

		[JsonProperty(PropertyName = "iban_extern", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExternalIBAN { get; set; } // IBANEXT

		[JsonProperty(PropertyName = "zona_sepa", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SEPAArea { get; set; } // ZONASEPA

		public Bank()
		{
		}
	}
}