/*
 * This class is use as the blueprint for the cache data. 
 * Will use to store a json representation into a nosql database.
 * 
 */
using Question2_RateProviders.DTOs;
using Question2_RateProviders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.Model
{
    public class CacheProviders
    {
        public List<ProvidersDto> Providers { get; set; }

        /*
         * Lifetime is checked against and default lifetime to 
         * see if the data is valid.
         */
        public DateTime Lifetime { get; set; }

        /*
         * This property is set to false when the data in the system database is changed.
         * Default value is true.
         * False signifies that the data is invalid.
         */
        public bool Valid { get; set; }


        public CacheProviders(List<ProvidersDto> _providersDtos)
        {
            Providers.Clear();
            Providers.AddRange(_providersDtos);
            Lifetime = DateTime.Now; //random number that can mean 1 day or hours
            Valid = true;
        }
    }
}
