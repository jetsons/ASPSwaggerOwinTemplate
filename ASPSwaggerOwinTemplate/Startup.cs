using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(ASPSwaggerOwinTemplate.Startup))]

namespace ASPSwaggerOwinTemplate {
	public class Startup {

		public virtual void Configuration(IAppBuilder app) {

			HttpConfiguration config = new HttpConfiguration();


			// Configure REST API
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "v1/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);


			// Configure JSON Formatter for REST API
			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


			// Configure CORS to allow JavaScript clients from any
			// domain to access our REST API
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);


			// Configure Swagger via Swashbuckle
			config
			.EnableSwagger(
				c => {
					c.SingleApiVersion("v1", "ASPSwaggerOwinTemplate");
				}
			)
			.EnableSwaggerUi();


			// Configure REST API
			app.UseWebApi(config);


		}

	}
}