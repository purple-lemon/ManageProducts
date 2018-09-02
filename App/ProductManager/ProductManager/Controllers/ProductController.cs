using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using ProductManager.Contracts.Services;
using ProductManager.Models.DTO;

namespace ProductManager.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/{version:apiVersion}/products")]
    public class ProductController : Controller
    {
		public IProductService Service { get; set; }
		public ProductController(IProductService service)
		{
			Service = service;
		}

		[HttpGet]
        public ActionResult<List<FullProductDTO>> Index()
        {
			return Ok(Service.Get());
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
			if (Service.VerifyCode(model.Code))
			{
				var added = Service.Add(model);
				return Created(Url.Action("Get", new { id = added.Id }), added);
			} else
			{
				return BadRequest(new
				{
					codeNotUnique = true
				});
			}
		}
    }
}