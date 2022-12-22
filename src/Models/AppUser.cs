using Microsoft.AspNetCore.Identity;

namespace RunGroupWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Mileare { get; set; }
        public Address? Addres { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
