/*
 * In the system, this is the API layer that is accessible by only authorize individuals.
 * This layer communicates with a service but is isolated from the rate providers. 
 * It only manages the request, response and security of the system. 
 * The different layers allows separation which benefits development.
 */

using Microsoft.AspNetCore.Mvc;
using Question2_RateProviders.DTOs;
using Question2_RateProviders.Entities;
using Question2_RateProviders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvidersController : ControllerBase
    {
        //provider service that communicates with the providers
        private IProviderServices _providerService;
        public ProvidersController(IProviderServices providerServices)
        {
            _providerService = providerServices;
        }

        /*
         * This endpoint returns all the providers in a list .
         * 
         */
        [HttpGet("")]
        public async Task<IActionResult> GetAllProviders()
        {
            List<ProvidersDto> providers = _providerService.getProviders();

            return Ok(providers);
        }

        /*
         * This endpoint returns a specific provider base on the it id and year if
         *  applicable.
         */
        [HttpGet("{providerId}")]
        public async Task<IActionResult> GetProvider([FromRoute] string providerId,
            [FromQuery] string year = null)
        {

            List<ProvidersDto> providers =  _providerService.getProviders(providerId, year);

            return Ok(providers[0]);
        }

        /*
         * This endpoint allows the client/user to add new providers to the system database.
         * Then the user/client is able to access their rates using the 
         * GetAllProviders.
         */
        [HttpPost("")]
        public async Task<IActionResult> AddProvider([FromBody] List<NewProviderDto> providers)
        {
            if(providers == null || providers.Count == 0)
            {
                return BadRequest(new { _error = "Providers list cannot be null" });
            }

           await _providerService.addProviders(providers);


            return Ok();
        }

         /*
          * This endpoint edits a single provider from the the system database.
          */

        [HttpPost("edit")]
        public async Task<IActionResult> EditProvider([FromBody] NewProviderDto provider)
        {
            if (provider == null)
            {
                return BadRequest(new { _error = "Body cannot be null. Provider object is needed." });
            }


            var result =  _providerService.editProvider(provider);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }


        /*
         * This endpoint handles the deleting of a provider from the system list
         * of providers
         */

        [HttpDelete("{providerId}")]
        public async Task<IActionResult> DeleteProvider([FromRoute] string providerId)
        {
            if (providerId == null)
            {
                return BadRequest(new { _error = "ProviderId is needed in url." });
            }


            var result = _providerService.deleteProvider(providerId);

            if (!result)
            {
                return NotFound();
            }

            return Ok(providerId);
        }


    }
}
