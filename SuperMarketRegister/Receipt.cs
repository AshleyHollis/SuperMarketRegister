using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ardalis.GuardClauses;

namespace SuperMarketRegister
{
    public class Receipt
    {
        private const decimal TaxPercentage = 10;

        private readonly List<Item> _items = new List<Item>();

        public decimal SubTotal => _items.Sum(item => item.Quantity * item.Amount);
        public decimal Tax => SubTotal / TaxPercentage;
        public decimal Total => SubTotal + Tax;

        public void AddItem(int qty, string itemName, decimal amount)
        {
            Guard.Against.OutOfRange(qty, nameof(qty), 0, int.MaxValue);
            Guard.Against.NullOrWhiteSpace(itemName, nameof(itemName));
            Guard.Against.OutOfRange((int) amount, nameof(amount), 0, int.MaxValue);

            var newItem = new Item(qty, itemName, amount);
            newItem.Validate();

            _items.Add(newItem);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            PrintLineItems(stringBuilder);
            PrintSubTotal(stringBuilder);
            PrintTax(stringBuilder);
            PrintTotal(stringBuilder);

            return stringBuilder.ToString();
        }

        private void PrintTotal(StringBuilder stringBuilder)
        {
            Guard.Against.Null(stringBuilder, nameof(stringBuilder));

            stringBuilder.Append($"Total = ${Total:0.00}");
        }

        private void PrintTax(StringBuilder stringBuilder)
        {
            Guard.Against.Null(stringBuilder, nameof(stringBuilder));

            stringBuilder.AppendLine($"Tax ({TaxPercentage}%) = ${Tax:0.00}");
        }

        private void PrintSubTotal(StringBuilder stringBuilder)
        {
            Guard.Against.Null(stringBuilder, nameof(stringBuilder));

            stringBuilder.AppendLine($"SubTotal = ${SubTotal:0.00}");
        }

        private void PrintLineItems(StringBuilder stringBuilder)
        {
            Guard.Against.Null(stringBuilder, nameof(stringBuilder));

            foreach (var item in _items)
            {
                stringBuilder.AppendLine(item.ToString());
            }
        }
    }
}