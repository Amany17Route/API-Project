using System.ComponentModel.DataAnnotations;

namespace Store.Data.Entity.IdentityEntity
{
    public class Address
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Street { get; set; }

        public string City { get; set; }


        public string State { get; set; }


        public string PostalCode { get; set; }

        [Required]

        public string AppUserID { get; set; }

        public AppUser AppUser { get; set; }

    }
}