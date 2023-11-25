﻿using MarienProject.Api.Extensions;
using MarienProject.Api.Extentions;
using MarienProject.Api.Models;
using MarienProject.Api.Repositories;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos;
using MarienProject.Models.Dtos.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly MarienPharmacyContext _dbPharmacyContext;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger, MarienPharmacyContext dbPharmacyContext)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _dbPharmacyContext = dbPharmacyContext;
        }

        [HttpGet]
        [Route("GelAllCustomers")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomers();

                if (customers == null)
                {
                    return NotFound();
                }
                else
                {
                    var customersDto = customers.ConvertToDto();
                    return Ok(customers);
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error retrieving data from the database");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        //{
        //    try
        //    {
        //        var customers = await _dbPharmacyContext.AllCustomerDatas.FromSqlRaw("uspGetAllCustomers").ToListAsync();

        //        if (customers == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(customers);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving data from the database");
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An unexpected error occurred");
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}



        [HttpGet]
        [Route("GetCustomerById/{id}")]

        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound(id);
                }
                else
                {
                    var customerDto = customer.ConvertToDto();
                    return Ok(customerDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCustomers")]
        public async Task<ActionResult<bool>> CreateCustomer([FromBody]CreateCustomerActions customerActions)
        {
            try
            {
                var userCustomer = customerActions.CreateCustomerActs();
                var createStaus = await _customerRepository.CreateCustomer((Customer)userCustomer[0], (UserProfile)userCustomer[1]);

                if (createStaus == false)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(createStaus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating an customer");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            try
            {
                var deleteStatus = await _customerRepository.DeleteCustomer(id);
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
                _logger.LogError(ex, "An error occurred while deleting an customer");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public async Task<ActionResult<bool>> UpdateCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = customerDto.ConvertToCustomer();
                var updateStatus = await _customerRepository.UpdateCustomer(customer);
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
                _logger.LogError(ex, "An error occurred while updating an customer");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

