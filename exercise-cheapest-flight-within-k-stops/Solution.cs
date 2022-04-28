namespace exercise_cheapest_flight_within_k_stops
{
    public static class Solution
    {
        public static int FindCheapestPrice(int cities, int[,] flightsArr, int source, int destination, int stops)
        {
            var flightsList = new List<Flight>();
            for(int i = 0; i < flightsArr.GetLength(0); i++)
            {
                flightsList.Add(new Flight(flightsArr[i, 0], flightsArr[i, 1], flightsArr[i, 2]));
            }            

            return FindCheapestPrice(cities, flightsList, source, destination, stops);
        }
      
        public static int FindCheapestPrice(int cities, IEnumerable<Flight> flights, int source, int destination, int stops)
        {
            var routes = new List<FlightRoute>();
            flights
                .Where(x => x.Source == source)
                .ToList()
                .ForEach(x => routes.Add(new FlightRoute(destination)
                {
                    Flights = new List<Flight> { x }
                }));

            var i = 0;
            while(i < routes.Count)
            {                
                var lastFlight = routes[i].Flights.Last();

                // it circled around
                if (lastFlight.Destination == source)
                {
                    i++;
                    continue;
                }
                
                var nextFlights = flights.Where(x => x.Source == lastFlight.Destination);
                if (nextFlights.Any())
                {
                    if(nextFlights.Count() > 1)
                    {
                        var clonedFlightRoute = FlightRoute.Clone(routes[i]);

                        if (!FlightRoute.DoesExistInRoute(routes[i], nextFlights.First()))
                        {
                            routes[i].Flights.Add(nextFlights.First());
                        }
                        
                        for(var j = 1; j < nextFlights.Count(); j++)
                        {
                            var nextFlight = nextFlights.ElementAt(j);
                            if (!FlightRoute.DoesExistInRoute(routes[i], nextFlight))
                            {
                                var newFlightRoute = FlightRoute.Clone(clonedFlightRoute);
                                newFlightRoute.Flights.Add(nextFlight);
                                routes.Add(newFlightRoute);
                            }                            
                        }
                    }
                    else
                    {
                        routes[i].Flights.Add(nextFlights.First());
                    }
                }
                else
                {
                    i++;
                }
            }

            var cheapestRoute = routes
                .Where(x => x.IsTargetFinalDestinationReached && x.Stops == stops)
                .OrderBy(x => x.TotalPrice)
                .FirstOrDefault();

            return cheapestRoute == null ? -1 : cheapestRoute.TotalPrice;
        }
    }
}
