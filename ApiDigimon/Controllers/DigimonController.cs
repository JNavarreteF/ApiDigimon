using ApiDigimon.Data;
using ApiDigimon.Models;
using ApiDigimon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigimon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DigimonController : ControllerBase
	{
		private readonly AppDbContext _dbContext;
		private readonly DigimonService _digimonService;

		public DigimonController(DigimonService digimonService, AppDbContext dbContext)
		{
			_digimonService = digimonService;
			_dbContext = dbContext;
		}

		[HttpGet("/")]
		public async Task<ActionResult<DigimonResponse>> GetAll()
		{
			var digimonResponse = await _digimonService.GetAllAsync();

			if (digimonResponse == null)
			{
				return NotFound();
			}

			return digimonResponse;
		}

		[HttpPost("/GetAndSave")]
		public async Task<ActionResult<List<Digimon>>> GetAndSave(int page, int pageSize)
		{
			var digimonJsons = await _digimonService.GetContentAsync(page, pageSize);
			List<Digimon> digimons = [];
			if (digimonJsons != null)
			{
				digimons = digimonJsons.Select(f => new Digimon {Id=Guid.Empty, Name = f.Name, Href = f.Href, Image = f.Href }).ToList();
				_dbContext.Digimons.AddRange(digimons);
				await _dbContext.SaveChangesAsync();
			}

			return digimons;
		}
	}
}
