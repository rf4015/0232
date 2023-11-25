using MarienProject.Api.Extensions;
using MarienProject.Api.Extentions;
using MarienProject.Api.Repositories;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarienProject.Api.Controllers
{
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<SaleController> _logger;

        public SaleController(ISaleRepository saleRepository, ILogger<SaleController> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllSales")]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetAllSales()
        {
            var sales = await _saleRepository.GetAllSales();

            if(sales == null)
            {
                return NotFound();
            }
            var salesDto = sales.ConvertToDto();
            return Ok(salesDto);
        }

        [HttpPost]
        [Route("CreateSale")]
        public async Task<ActionResult<bool>> CreateSale([FromBody] SaleActionsDto saleDto)
        {
            try
            {
                var sale = saleDto.ConvertAddToSale();
                var result = await _saleRepository.CreateSale(sale);

                if(result == false) 
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating an sale");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetSaleById/{id}")]
        public async Task<ActionResult<SaleDto>> GetSaleById(int id)
        {
            try
            {
                var sale = await _saleRepository.GetSaleById(id);
                if (sale == null)
                {
                    return NotFound(id);
                }
                else
                {
                    var saleDto = sale.ConvertToDto();
                    return Ok(saleDto);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while retrieving sale data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSale/{id}")]
        public async Task<ActionResult<bool>> UpdateSale(int id, SaleActionsDto saleDto)
        {
            try
            {
                var sale = saleDto.ConvertAddToSale();
                var updateStatus = await _saleRepository.UpdateSale(id, sale);
                if (updateStatus == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an sale");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSale/{id}")]
        public async Task<ActionResult<bool>> DeleteSale(int id)
        {
            try
            {
                var deleteStatus = await _saleRepository.DeleteSale(id);
                if (deleteStatus == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an sale");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
