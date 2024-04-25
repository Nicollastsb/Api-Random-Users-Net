namespace RandomUser.Domain.Entities
{
    public class RandomicUserLocation
    {
        public RandomicUserLocationStreet Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal Postcode { get; set; }
        public RandomUserLocationCoordinates Coordinates { get; set; }
        public RandomicUserLocationTimezone Timezone { get; set; }
    }
}
