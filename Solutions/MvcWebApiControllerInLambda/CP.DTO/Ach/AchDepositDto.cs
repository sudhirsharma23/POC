namespace CP.DTO.Ach
{
    public class AchDepositDto
    {
        public int ConsumerFileId { get; set; }
        public int FastFileId { get; set; }
        public double Amount { get; set; }
        public string AccountType { get; set; }
        public string BankingType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }
}