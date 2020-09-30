using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Dto;
using Seed.CrossCuting;
using System;

namespace Seed.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase<ResourceDto>
    {
        public ResourceController(IResourceApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
            : base(app, logger, env, new ErrorMapCustom())
        {



        }

        [Authorize(Policy = "CanReadAll")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ResourceFilter filters)
        {
            return await base.Get<ResourceFilter>(filters, "Seed - Resource");
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadOne")]
        public async Task<IActionResult> Get(int id, [FromQuery] ResourceFilter filters)
        {
            if (id.IsSent()) filters.ResourceId = id;
            return await base.GetOne(filters, "Seed - Resource");
        }

        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourceDtoSpecialized dto)
        {
            return await base.Post(dto, "Seed - Resource");
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ResourceDtoSpecialized dto)
        {
            return await base.Put(dto, "Seed - Resource");
        }
        [Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ResourceDtoSpecialized dto)
        {
            if (id.IsSent()) dto.ResourceId = id;
            return await base.Delete(dto, "Seed - Resource");
        }
    }
}
