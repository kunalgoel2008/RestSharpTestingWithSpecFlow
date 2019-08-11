
namespace RestSharpTesting.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public int OrganisationId { get; set; }
        public int AddressID { get; set; }
        public string MobileNo { get; set; }
        public string Alt_MobNo { get; set; }
        public bool isDeleted { get; set; }
        public Address address { get; set; }
    }
}
