using dotAshFashionNexus.API.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using dotAshFashionNexus.Service.IServices;
using dotAshFashionNexus.Service.DTO;
namespace dotAshFashionNexus.API.Controllers
{
    
    
    [Route("api/ProductAPI")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        protected APIResponse _response;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
            _response = new();
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> GetProductsAsync(int pageSize = 10, int pageNumber = 1, string filterBy = null, string sortBy = "Name")
        {
            try
            {

                IEnumerable<ProductDTO> productDTOList = await _productService.GetAllProductsAsync(filterBy: filterBy, sortBy: sortBy, pageSize: pageSize, pageNumber: pageNumber);

                _response.Result = productDTOList;
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogInformation("getting all products");
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error :" + ex);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> GetProductByFriendlyNameAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _logger.LogError("get product error with Id " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                ProductDTO product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { "Product not found." };
                    return NotFound(_response);
                }
                _response.Result = product;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);

            }

        }


    }
}
