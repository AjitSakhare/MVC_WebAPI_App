namespace DataAccessComponent
{
    public class ContactInfoDALEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }
        public bool? Status { get; set; }
    }
}