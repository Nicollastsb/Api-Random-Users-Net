using RandomUser.Domain.Entities;

namespace RandomUser.Infra.Data.Entities
{
    public class Result
    {
        public List<RandomicUser> Results { get; set; }
        public Info Info { get; set; }
    }
}
