using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheProject.Model;

namespace CacheProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var videos = new List<Video>();
            var endpoints = new List<Endpoint>();
            var caches = new List<Cache>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"trending_today.in");
            var firstLine = file.ReadLine();
            var videoSizeLine = file.ReadLine();
            
                var requestInformation = firstLine.Split(' ');
                var videoSize = videoSizeLine.Split(' ');

            //videos

                for (var i = 0; i < int.Parse(requestInformation[0]); i++)
                {
                    videos.Add(new Video
                    {
                        Id = i,
                        Size = int.Parse(videoSize[i])
                    });
                }

            //endpoints

                for (var i = 0; i < int.Parse(requestInformation[1]); i++)
                {
                    var endpointsIn = file.ReadLine().Split(' ');
                    var latencies = new Dictionary<int, int>();

                        for (var y = 0; y < int.Parse(endpointsIn[1]); y++)
                        {
                            var endPointLatency = file.ReadLine().Split(' ').Select(int.Parse).ToArray();
                            latencies.Add(endPointLatency[0], endPointLatency[1]);
                        }


                    endpoints.Add(new Endpoint
                    {
                        Id = i,
                        LatencyToDataCenter = int.Parse(endpointsIn[0]),
                        LatencyToCache = latencies,
                        RequestDescriptions = new List<RequestDescription>()
                    });
                }

                //requestDescriptions
                for (var i = 0; i < int.Parse(requestInformation[2]); i++)
                {
                    var requestDescriptionsIn = file.ReadLine().Split(' ');


                    endpoints[int.Parse(requestDescriptionsIn[1])].RequestDescriptions.Add(new RequestDescription()
                    {
                        NoRequests = int.Parse(requestDescriptionsIn[2]),
                        Video = videos.FirstOrDefault(y => y.Id == int.Parse(requestDescriptionsIn[0]))                   
                    });
                    
                }


            //caches

                for (var i = 0; i < int.Parse(requestInformation[3]); i++)
                {
                    caches.Add(new Cache
                    {
                        Id = i,
                        Size = int.Parse(requestInformation[4])
                    });
                }

            int cacheNumber = 3;
            List<CacheCombinationList> caches2 = new List<CacheCombinationList>();
            List<CacheCombinationList> resultCaches = new List<CacheCombinationList>();
            
            for (int i = 0; i < cacheNumber; i++)
            {   
                caches2.Add(new CacheCombinationList());    
            }

            foreach (var c in caches2)
            {
                CacheCombination finalCombination = c.Combinations.OrderBy(x => x.TotalEffectiveTimeSaved).FirstOrDefault();
                c.Combinations = new List<CacheCombination>(); 
                c.Combinations.Add(finalCombination);
            }


        }
    }
}
