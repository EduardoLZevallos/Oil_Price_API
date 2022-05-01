using System;
namespace OilPrice.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
		public string StatusDescription { get; set; }
		public List<ConventionalGasoline>? ConventionalGasolines { get; set; }
		public List<CrudeOil>? CrudeOils { get; set; }
	}
}

