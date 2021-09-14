/*
 * This entity represents a single table inside of the system database.
 * It stores the necessary information of a provider and the link needed
 * to get the rates.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Question2_RateProviders.Entities
{
    public class Provider
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }

        public int Term { get; set; }

        //link used to get the provider rate
        public string ProviderLink { get; set; }

    }
}
