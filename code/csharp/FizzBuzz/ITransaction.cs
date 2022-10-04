namespace FizzBuzz
{
    public interface ITransaction
    {
        int Value  { get; }
        string ToPrintable();
    }

    public class Transaction : ITransaction
    {
        readonly private int _Value;
        public int Value => _Value;

        public Transaction(int value) => this._Value = value;

        public string ToPrintable()
        {
            return $"Value: {Value}";
        }
    }

    public class Workflow
    {
        public static Func<IEnumerable<ITransaction>, string> ToPrintableOnlyPositive = transactions =>
        {
            return String.Join("\r\n", transactions
                .Where(t => t.Value > 0)
                .Select(t => t.ToPrintable())
                );
        };
    }
}
