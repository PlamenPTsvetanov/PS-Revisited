namespace UserLogin
{
    public class User
    {
        public Int32 Id { get; set; }
        public String _username { get; set; }
        public  String _password { get; set; }
        public String _facultyNumber { get; set; }
        public Int32 _role { get; set; }
        public DateTime _creationDate { get; set; }
        public DateTime _validTo { get; set; }
    }
}
