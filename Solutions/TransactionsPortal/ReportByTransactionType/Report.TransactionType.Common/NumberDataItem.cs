namespace Report.TransactionType.Common
{
    public class NumberDataItem
    {
        public NumberDataItem(string name, int number)
        {
            Name = name;
            Number = number;
        }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
