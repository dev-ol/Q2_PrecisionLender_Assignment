/*
 * This is the service layer that communicates with the different Providers and
 * to the system database.
 */
using Question2_RateProviders.DTOs;
using Question2_RateProviders.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question2_RateProviders.Services
{
    public interface IProviderServices
    {
         
        /*
         * This method connects to the database and grab all the providers.
         * Afterwards using the Provider's link, in parrallel, calls are maded to
         * the different providers to get the rates.
         * The results are cache to reduce latency on back to back calls. Assuming the data
         * is relevant for a hour to a day. The method checks the cache for data before
         * going through the previous process. 
         * It also gets a single provider and a particular year if specify.
         */
        public List<ProvidersDto> getProviders(string providerId = null, string year = null);


        /*
         * Async call that adds new providers to the system database.
         * The cache is set to invalid and updated after the next call.
         */
        public Task<bool> addProviders(List<NewProviderDto> providers);

        /*
         * Async call that delete a provider  from the system database.
         * The cache is set to invalid and updated after the next call.
         */
        public bool deleteProvider(string providerId);


        /*
         * Async call that edits a provider  in the system database.
         * The cache is set to invalid and updated after the next call.
         */
        public bool editProvider(NewProviderDto editedProvider);

    }
}