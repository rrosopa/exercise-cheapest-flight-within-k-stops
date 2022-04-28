using exercise_cheapest_flight_within_k_stops;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class SolutionTests
    {
        List<int[,]> TestData = new List<int[,]>
        {
            new int[5, 3] 
            {
                { 0, 1, 100 },
                { 1, 2, 100 },
                { 2, 0, 100 },
                { 1, 3, 600 },
                { 2, 3, 200 }
            },
            new int[3, 3] 
            {
                { 0, 1, 100 },
                { 1, 2, 100 },
                { 0, 2, 500 }
            },
            new int[3, 3]
            {
                { 0, 1, 100 },
                { 1, 2, 100 },
                { 0, 2, 500 }
            },
            new int[8, 3]
            {
                { 0, 1, 100 },
                { 1, 2, 100 },
                { 2, 0, 100 },
                { 1, 3, 600 },
                { 2, 3, 200 },
                { 0, 4, 200 },
                { 2, 4, 200 },
                { 3, 4, 200 }
            },
        };

        [Theory]
        [InlineData(4, 0, 0, 3, 1, 700)]
        [InlineData(4, 0, 0, 3, 2, 400)]
        [InlineData(3, 1, 0, 2, 1, 200)]
        [InlineData(3, 2, 0, 2, 0, 500)]
        [InlineData(4, 3, 0, 4, 3, 600)]
        [InlineData(4, 3, 0, 4, 2, 400)]
        [InlineData(4, 3, 0, 4, 0, 200)]        
        public void FindCheapestPrice(int cities, int testDataIndex, int source, int destination, int stops, int expectedPrice)
        {
            var sut = Solution.FindCheapestPrice(cities, TestData[testDataIndex], source, destination, stops);
            Assert.Equal(expectedPrice, sut);
        }
    }
}