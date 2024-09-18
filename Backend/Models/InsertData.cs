namespace Personal_Project.Models
{
    public class InsertData
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string AadharCard { get; set; }
        public string PanCard { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
