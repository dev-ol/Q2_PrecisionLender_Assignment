/*
 * Information about the class is in the interface
 */
using Question2_RateProviders.DTOs;
using Question2_RateProviders.Entities;
using Question2_RateProviders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.Services
{
    public class ProviderServices : IProviderServices
    {
        

        private ProviderDbContext _providerDbContext; //represent the sql database
        private  CacheProviders cache; // represents the nosql database for caching
        public ProviderServices(ProviderDbContext providerDbContext)
        {
            _providerDbContext = providerDbContext;
           
        }


        public async Task<bool> addProviders(List<NewProviderDto> providers)
        {
            //loops through providers to add
            foreach(NewProviderDto p in providers)
            {
                if (!ProviderExist(p))
                {
                    //adding new provider
                    _providerDbContext.Add(MapDto(p));

                }
            }

           await _providerDbContext.SaveChangesAsync();
           cache.Valid = false; //cache is now invalid

            return true;
        }

      

        public  bool deleteProvider(string providerId)
        {
            //find provider
            var provider = _providerDbContext.
                Providers.Where(x => x.Id == providerId).FirstOrDefault();

            if(provider != null)
            {
                return false;
            }

            _providerDbContext.Remove(provider);
            cache.Valid = false; //cache is now invalid

            return true;
     
        }


        public bool editProvider(NewProviderDto editedProvider)
        {
            //find provider
            var provider = _providerDbContext.
               Providers.Where(x => x.Id == editedProvider.Id).FirstOrDefault();

            if (provider != null)
            {
                return false;
            }

            _providerDbContext.Update(provider);
            cache.Valid = false; //cache is now invalid
            return true;

        }

        public List<ProvidersDto> getProviders(string providerId = null, string year = null)
        {
            //checks the cache; if true return cache data
            if (checkCache())
            {
                return getProvidersFromCache().Providers;
            }

            var providers = _providerDbContext.Providers.ToList();

            // attached the rates to the providers
            var providerRates = GetRates(providers);

            //updates cache with new data
            updateCache(providerRates);

            return providerRates;
        }


        /*check if cache data in a NoSql database and can be used.
        * This check is base off the default lifetime that is set (e.g 1 hour, 1 day...)
        * against the lifetime in CacheProvider class.
        * Also the invalid property in the same class is used because it supersedes 
        * the lifetime property
        */
        private bool checkCache()
        {
            /*
             * Cache in a NoSql database like Mongodb
             */
            throw new NotImplementedException();
        }

        //get the provider cached list from a nosql database
        private CacheProviders getProvidersFromCache()
        {
            throw new NotImplementedException();
        }


        /*
         * This method  calls the providers link/api in parallel to 
         * get the rates for each and store the information in a Providers Dto
         * 
         */
        private List<ProvidersDto> GetRates(List<Provider> providers)
        {
            List<ProvidersDto> dtos = new List<ProvidersDto>();

            //run the http calls in parallel.
            Parallel.ForEach(providers, (p) =>
            {
                var url = p.ProviderLink;
                /*
                 * Make Http call to provider using the url
                 * The data is digested in ProvidersDto Objects
                 * then added to the dtos list
                 * if error, that provider is not added and error is 
                 * log in some logging platform like Splunk.
                 */
            });

            return dtos;
        }

        /*
         * Updates the cache 
         * 
         */
        private void updateCache(List<ProvidersDto> providersDtos)
        {
            cache = new CacheProviders(providersDtos);

            /*
             * Note: Cache function is not complete implemented. 
             * Cache function would connect to a NoSql Db like Mongo to 
             * store cache data.
             */
        }


        //converts the dto into a Provider object
        private Provider MapDto(NewProviderDto p)
        {
            throw new NotImplementedException();
        }

        //checks database if provider exists
        private bool ProviderExist(NewProviderDto p)
        {
            throw new NotImplementedException();
        }
    }
}
