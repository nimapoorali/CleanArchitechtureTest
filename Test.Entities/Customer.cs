using System.ComponentModel.DataAnnotations;

namespace Test.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public ulong PhoneNumber { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}