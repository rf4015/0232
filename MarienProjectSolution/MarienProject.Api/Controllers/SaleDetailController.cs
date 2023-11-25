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
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailRepository _saleDetailRepository;
        private readonly ILogger<SaleDetailController> _logger;

        public SaleDetailController(ISaleDetailRepository saleDetailRepository, ILogger<SaleDetailController> logger)
        {
            _saleDetailRepository = saleDetailRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllSaleDetails")]
        public async Task<ActionResult<IEnumerable<SaleDetailDto>>> GetAllSalesDetails()
        {
            var sales = await _saleDetailRepository.GetAllSalesDetails();

            if (sales == null)
            {
                return NotFound();
            }
            var salesDto = sales.ConvertToDto();
            return Ok(salesDto);
        }


        [HttpPost]
        [Route("CreateSaleDetail")]
        public async Task<ActionResult<bool>> CreateSale([FromBody] SaleDetailActionsDto saleDto)
        {
            try
            {
                var sale = saleDto.ConverToAddSaleDetail();
                var result = await _saleDetailRepository.CreateSaleDetail(sale);

                if (result == false)
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
        [Route("GetSaleDetailById/{id}")]
        public async Task<ActionResult<SaleDetailDto>> GetSalesDetailsById(int id)
        {
            try
            {
                var sale = await _saleDetailRepository.GetSaleDetailsById(id);
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

        [HttpDelete]
        [Route("DeleteSaleDetail/{id}")]
        public async Task<ActionResult<bool>> DeleteSaleDetail(int id)
        {
            try
            {
                var deleteStatus = await _saleDetailRepository.DeleteSaleDetail(id);
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
                _logger.LogError(ex, "An error occurred while deleting an saleDetail");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateSaleDetails(int id, [FromBody] SaleDetailActionsDto sale)
        {
            try
            {
                var updateSale = sale.ConverToAddSaleDetail();
                var result = await _saleDetailRepository.UpdateSaleDetail(id, updateSale);

                if(result == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an saleDetail");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
