namespace RandomUser.Domain.Entities
{
    public class RandomicUser
    {
        public string Gender { get; set; }
        public RandomicUserName Name { get; set; }
        public RandomicUserLocation Location { get; set; }
        public string Email { get; set; }
        public RandomicUserLogin Login { get; set; }
        public RandomicUserDateOfBirth Dob { get; set; }
        public RandomicUserRegistered registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public RandomicUserId Id { get; set; }
        public RandomicUserPicture Picture { get; set; }
        public string Nat { get; set; }
    }
}
