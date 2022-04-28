// See https://aka.ms/new-console-template for more information
using exercise_cheapest_flight_within_k_stops;

var result = Solution.FindCheapestPrice(
    4,
    new int[5, 3] {
        { 0, 1, 100 },
        { 1, 2, 100 },
        { 2, 0, 100 },
        { 1, 3, 600 },
        { 2, 3, 200 }
    },
    0,
    3,
    2
);

Console.WriteLine("Cheapest price: {0}", result);



