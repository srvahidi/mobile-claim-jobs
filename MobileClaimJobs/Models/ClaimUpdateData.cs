using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Models
{
    public class ClaimUpdateData
    {
        [JsonProperty("customerStatus")]
        public int CustomerStatus { get; set; }
    }
}
