/*
 * This is a data transfer object which is used to communicate between the client of the api
 * and the system's API.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.DTOs
{
    public class NewProviderDto
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public int Term { get; set; }

        //link used to get the provider rate
        public string ProviderLink { get; set; }
    }
}
