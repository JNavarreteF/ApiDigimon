using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiDigimon.Models
{
	public class DigimonResponse
	{
		[JsonPropertyName("content")]
		public List<DigimonJson> Content { get; set; }
		[JsonPropertyName("pageable")]
		public Pageable Pageable { get; set; }
	}
	public class Pageable
	{
		[JsonPropertyName("currentPage")]
		public int CurrentPage { get; set; }
		[JsonPropertyName("elementsOnPage")]
		public int ElementsOnPage { get; set; }
		[JsonPropertyName("totalElements")]
		public int TotalElements { get; set; }
		[JsonPropertyName("totalPages")]
		public int TotalPages { get; set; }
		[JsonPropertyName("previousPage")]
		public string PreviousPage { get; set; }
		[JsonPropertyName("nextPage")]
		public string NextPage { get; set; }
	}

	public class DigimonJson
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("href")]
		public string Href { get; set; }
		[JsonPropertyName("image")]
		public string Image { get; set; }
	}
}
