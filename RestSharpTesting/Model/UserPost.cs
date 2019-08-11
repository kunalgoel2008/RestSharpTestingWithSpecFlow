
namespace RestSharpTesting.Model
{
    public class UserPost
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public int Position_Id { get; set; }
        public int Organisation_Id { get; set; }
        public int Address_ID { get; set; }
        public string Mob_No { get; set; }
        public string Alt_Mob_No { get; set; }
        public bool isDeleted { get; set; }
        public Address1 address { get; set; }
    }
}
