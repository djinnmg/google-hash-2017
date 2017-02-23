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

        public int LatencyToDataCenter;

        public Dictionary<Cache, int> LatencyToCache;

    }
}
