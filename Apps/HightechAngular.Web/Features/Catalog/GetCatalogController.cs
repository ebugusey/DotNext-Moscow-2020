using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.Catalog
{
    public class CatalogController: ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductListItem), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] GetProducts query)
        {
            return this.Process(query);
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            return this.Process(new GetCategories());
        }
    }
}
