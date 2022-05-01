using System;
using System.ComponentModel.DataAnnotations;

namespace OilPrice.Models
{
	public class CrudeOil
	{
		[Key]
		public int CrudeOilID { get; set; }
		public int Date { get; set; }
		public double WTI { get; set; }
		public double BRENT { get; set; }
		//public int ConventionalGasID { get; set; }
	}

}




