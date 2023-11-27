using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApiDigimon.Models
{
	[Table("DIGIMONS")]
	public class Digimon
	{
		[Key]
		[Column("ID")]
		public Guid Id { get; set; }
		[Required]
		[Column("NAME")]
		[Unicode(false)]
		public string Name { get; set; }
		[Required]
		[Column("HREF")]
		[Unicode(false)]
		public string Href { get; set; }
		[Required]
		[Column("IMAGE")]
		[Unicode(false)]
		public string Image { get; set; }
	}
}
