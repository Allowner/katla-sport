using KatlaSport.Services.HiveManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/items")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ItemsController : ApiController
    {
        private readonly IHiveSectionProductService _hiveSectionProductService;

        public ItemsController(IHiveSectionProductService hiveSectionProductService)
        {
            _hiveSectionProductService = hiveSectionProductService ?? throw new ArgumentNullException(nameof(hiveSectionProductService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of products.", Type = typeof(HiveSectionProduct[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionProducts()
        {
            var items = await _hiveSectionProductService.GetHiveSectionProductsAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("{itemId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section product.", Type = typeof(HiveSectionProduct))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionProduct(int itemId)
        {
            var item = await _hiveSectionProductService.GetHiveSectionProductAsync(itemId);
            return Ok(item);
        }

        [HttpPut]
        [Route("{itemId:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed item.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int itemId, [FromUri] bool deletedStatus)
        {
            await _hiveSectionProductService.SetStatusAsync(itemId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{itemId:int:min(1)}/deliveredStatus/{deliveredStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets delivered status for an existed item.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetDeliveredStatus([FromUri] int itemId, [FromUri] bool deliveredStatus)
        {
            await _hiveSectionProductService.SetDeliverStatusAsync(itemId, deliveredStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new item.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddHiveSectionProduct([FromBody] UpdateHiveSectionProductRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _hiveSectionProductService.CreateHiveSectionProductAsync(createRequest);
            var location = string.Format("/api/items/{0}", item.Id);
            return Created<HiveSectionProduct>(location, item);
        }

        [HttpPut]
        [Route("{itemId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existing item.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHiveSectionProduct([FromUri] int itemId, [FromBody] UpdateHiveSectionProductRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hiveSectionProductService.UpdateHiveSectionProductAsync(itemId, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{itemId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existing item.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteHiveSectionProduct([FromUri] int itemId)
        {
            await _hiveSectionProductService.DeleteHiveSectionProductAsync(itemId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
