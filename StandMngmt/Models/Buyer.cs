using System.ComponentModel.DataAnnotations;

namespace StandMngmt.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
