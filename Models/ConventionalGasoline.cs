using System;
using System.ComponentModel.DataAnnotations;

namespace OilPrice.Models
{

	public class ConventionalGasoline
    {
		[Key]
		public int ConventionalGasID { get; set; }
		public int Date { get; set; }
		public double NewyorkHarbor { get; set; }
		public double USGulfCoast { get; set; }
    }
}



