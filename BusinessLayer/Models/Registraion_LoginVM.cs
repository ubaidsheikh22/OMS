namespace BusinessLayer.Models
{
    public class Registraion_LoginVM
    {
        public Login Login { get; set; }
        public user User { get; set; }
    }
    public class JsonLoginRegistration
    {
        public int User_ID { get; set; }
        public int Login_ID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Pass { get; set; }
        public int Role_ID { get; set; }
        public int IsLogin { get; set; }
        public string IPAddress { get; set; }
        public string DesigantionDesc { get; set; }
        public string Distributor_ID { get; set; }
        public string Distribution_Desc { get; set; }
        public string Rele_Desc { get; set; }
        public int Designation_ID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string RegionCode { get; set; }
        public string AreaCode { get; set; }
        public string TerritoryCode { get; set; }
        public string TownCode { get; set; }
        public string Organization { get; set; }
        public string Division { get; set; }
        public string Active { get; set; }
    }
}
