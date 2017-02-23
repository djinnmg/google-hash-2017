using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheProject.Model
{
    class Endpoint
    {
        public int Id;

        public RequestDescription RequestDescription;

        public int LatencyToDataCenter;

        // cacheId to cacheLatency
        public Dictionary<int, int> LatencyToCache;


    }
}
