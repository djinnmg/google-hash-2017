using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CacheProject.Model;

namespace CacheProject
{
    class ComparitorMapper
    {

        public static List<ComparitorObject> Map(List<Endpoint> endpoints)
        {
            var comparitorObjects = new List<ComparitorObject>();

            foreach (var endPoint in endpoints)
            {
                foreach (var requestDescription in endPoint.RequestDescriptions)
                {
                    foreach (var latencyToCacheKvp in endPoint.LatencyToCache)
                    {
                        var timeSaved = endPoint.LatencyToDataCenter - latencyToCacheKvp.Value;
                        var totalTimeSaved = timeSaved*requestDescription.NoRequests;

                        var comparitorObject = new ComparitorObject
                        {
                            CacheId = latencyToCacheKvp.Key,
                            EndpointId = endPoint.Id,
                            VideoId = requestDescription.Video.Id,
                            EffectiveTimeSaved = totalTimeSaved
                        };
                        comparitorObjects.Add(comparitorObject);
                    }
                }
            }



            return comparitorObjects;
        }

    }
}
