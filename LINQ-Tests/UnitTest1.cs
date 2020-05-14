using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xunit;
using static Lab09_LINQ.GetJsonTypes;

namespace LINQ_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReadFile()
        {
            string filename = "data.json";
            string data = File.ReadAllText(filename);

            Assert.NotEmpty(data);

            RootObject geojson = JsonConvert.DeserializeObject<RootObject>(data);

            Assert.NotNull(geojson);

            Assert.Equal("10001", geojson.features.First().properties.zip);
            Assert.NotEmpty(
                geojson.features
                    .Select(feature => feature.properties.zip)
                    .Distinct()
                );

            Assert.Equal(147, geojson.features.Count());
        }

        [Fact]
        public void OutputAllNeighborhoodsTest()
        {
            string filename = "data.json";
            string data = File.ReadAllText(filename);

            RootObject geojson = JsonConvert.DeserializeObject<RootObject>(data);

            IEnumerable<string> allNeighborhoods =
                geojson.features
                   .Select(feature => feature.properties.neighborhood);

            Assert.Equal(147, allNeighborhoods.Count());
                   
        }

    }
}
