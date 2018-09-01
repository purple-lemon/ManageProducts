using Microsoft.AspNetCore.Mvc;
using ProductManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Controllers.v2
{
	[ApiVersion("2.0")]
	[Route("api/{version:apiVersion}/products")]
	public class ProductController : Controller
	{
		[HttpGet]
		public ActionResult<List<FullProductDTO>> Index()
		{
			return Ok(new List<FullProductDTO>()
			{
				new FullProductDTO(){ Name = "asd", Price = 100 },
				new FullProductDTO(){ Name = "qwe", Price = 200 }
			});
		}

		[Route("{id}")]
		[HttpGet]
		public ActionResult<FullProductDTO> Get([FromQuery]int id)
		{
			return Ok(new FullProductDTO() { Name = "asd", Price = 100 });
		}

		[HttpPost]
		public ActionResult<FullProductDTO> Add([FromBody]ProductBaseDTO model)
		{
			return Created(Url.Action("Get", new { id = 10 }), new FullProductDTO());
		}
	}
}
