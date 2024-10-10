namespace BrokerAPI.DTOs
{
    public class BrokerDto
    {
        public int BrokerId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public long Pincode { get; set; }
        public long AdhaarCard { get; set; }
    }
}
