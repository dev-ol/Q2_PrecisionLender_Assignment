/*
 * This DTO is used to return the favorable response from the API request 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.DTOs
{
    public class ProvidersDto
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public int Term { get; set; }
        public double Rate { get; set; }

        public ProvidersDto()
        {
                
        }
    }
}

/**
 * Name Term Rate
LIBOR 1 month 1 0.004969
LIBOR 2 months 2 0.006105
LIBOR 3 months 3 0.007776
LIBOR 6 months 6 0.011442
LIBOR 12 months 12 0.014546
 */
