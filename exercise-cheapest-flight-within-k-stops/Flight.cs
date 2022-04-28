namespace exercise_cheapest_flight_within_k_stops
{
    public class Flight
    {
        public Flight(int source, int destination, int price)
        {
            Source = source;
            Destination = destination;
            Price = price;
        }

        public int Source { get; set; }
        public int Destination { get; set; }
        public int Price { get; set; }
    }

    public class FlightRoute
    {
        public FlightRoute(int targetFinalDestination)
        {
            Id = Guid.NewGuid();
            Flights = new List<Flight>();
            TargetFinalDestination = targetFinalDestination;
        }

        public Guid Id { get; set; }
        public List<Flight> Flights { get; set; }
        public int TargetFinalDestination { get; set; }

        public int TotalPrice => Flights.Sum(x => x.Price);
        public int Stops => Flights.Count - 1;
        public bool IsTargetFinalDestinationReached => Flights.Last().Destination == TargetFinalDestination;

        public static FlightRoute Clone(FlightRoute route)
        {
            var newRoute = new FlightRoute(route.TargetFinalDestination);
            newRoute.Flights.AddRange(route.Flights.Select(x => new Flight(x.Source, x.Destination, x.Price)));

            return newRoute;
        }

        public static bool DoesExistInRoute(FlightRoute route, Flight flight)
        {
            return route.Flights.Any(x => x.Source == flight.Source && x.Destination == flight.Destination);
        }
    }
}
