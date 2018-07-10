namespace SuperMarketRegister
{
    public class Item
    {
        public int Quantity { get; }
        public string ItemName { get; }
        public decimal Amount { get; }

        public Item(int qty, string name, decimal amount)
        {
            Quantity = qty;
            ItemName = name;
            Amount = amount;

            Validate();
        }

        public void Validate()
        {
            // TODO: Add validation logic here and throw a ItemNotValid exception.
        }

        public override string ToString()
        {
            // 1 Candy Bar @ $0.50 = $0.50
            var lineAmount = Quantity * Amount;

            return $"{Quantity} {ItemName} @ ${Amount:0.00} = ${lineAmount:0.00}";
        }
    }
}
