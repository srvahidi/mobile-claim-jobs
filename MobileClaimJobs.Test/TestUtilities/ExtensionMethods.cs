//using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClaimJobs.Test.TestUtilities
{
    public static class ExtensionMethods
    {
        // Deep clone
        public static T DeepClone<T>(this T a)
        {
            var stringObj = JsonConvert.SerializeObject(a);
            return JsonConvert.DeserializeObject<T>(stringObj);
        }
    }
}
