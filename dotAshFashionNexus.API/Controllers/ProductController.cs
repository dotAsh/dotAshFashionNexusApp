using dotAshFashionNexus.API.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using dotAshFashionNexus.Service.IServices;
using Microsoft.EntityFrameworkCore;
using dotAshFashionNexus.Service;

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



        [HttpGet("GetProductByFriendlyName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetProductByFriendlyNameAsync(string SearchEngineFriendlyName)
        {
            try
            {
                if (string.IsNullOrEmpty(SearchEngineFriendlyName))
                {
                    _response.IsSuccess = false;
                    _logger.LogError("get product error with SearchEngineFriendlyName ");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                ProductDTO product = await _productService.GetProductByNameAsync(SearchEngineFriendlyName);
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
        
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetProductsAsync
            (string? ProductName, string? VariantColor, string? VariantSize,
             string? WarehouseName, int PageSize = 10, int PageNumber = 1, bool InStock = true){

            ProductFilterCriteriaDTO filterCriteria = new ProductFilterCriteriaDTO
            {
                InStock = InStock,
                VariantColor = VariantColor,
                VariantSize = VariantSize,
                WarehouseName = WarehouseName,
                ProductName = ProductName,
                PageSize = PageSize,
                PageNumber = PageNumber
            };

            try
            {

                IEnumerable<Object> productDTOList = await _productService.GetAllProductsAsync(filterCriteria);

                _response.Result = productDTOList;
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogInformation("getting all products with variant wise stocks");
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

        [HttpPost("PlaceOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> PlaceOrderAsync(int stockId, int variantId, int warehouseId, int quantity)
        {
            try
            {
               
                if (quantity <= 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Quantity must be greater than 0." };
                    return BadRequest(_response);
                }


               
                var paymentResult = true; // Mock payment operation

                if (paymentResult)
                {
                    
                    await _productService.UpdateStockAsync(stockId, variantId, warehouseId, quantity);

                    _response.IsSuccess = true;
                    _response.Result = new { Message = "Order placed successfully." };
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Payment failed." };
                    return BadRequest(_response);
                }
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
