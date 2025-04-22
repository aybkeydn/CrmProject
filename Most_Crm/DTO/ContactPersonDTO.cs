namespace Most_Crm.DTOs
{
    public class ContactPersonDTO
    {
        public int ContactPersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }


        public int CustomerID { get; set; }

        public List<ContactPersonDTO> ContactPersons { get; set; } = new();

    }
}
