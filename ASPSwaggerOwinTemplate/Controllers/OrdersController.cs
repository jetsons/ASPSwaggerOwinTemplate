using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPSwaggerOwinTemplate.Controllers
{
    [RoutePrefix("api/v1")]
    public class OrdersController : ApiController {

		[AllowAnonymous]
		[HttpGet]
		[Route("orders/{orderId}")]
		public IHttpActionResult GetOrder([FromUri]string orderId) {
			return Ok();
		}

		[AllowAnonymous]
		[HttpGet]
		[Route("orders/")]
		public IHttpActionResult ListAllOrders() {
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		[Route("order/{orderId}")]
		public IHttpActionResult CreateOrder([FromUri]string orderId) {
			return Ok();
		}


		[Authorize(Roles = "Admin")]
		[HttpDelete]
		[Route("order/{orderId}")]
		public IHttpActionResult DeleteOrder([FromUri]string orderId) {
			return Ok();
		}

	}
}
