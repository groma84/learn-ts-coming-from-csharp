namespace FizzBuzz
{
    public class FizzBuzzer
    {
        private readonly int upTo;

        public FizzBuzzer(int upTo) => this.upTo = upTo;
        
        private string NumToString(int num)
        {
            if (num % 15 == 0) {
                return "FizzBuzz";
            }
            else if (num % 5 == 0) {
                return "Buzz";
            }
            else if (num % 3 == 0) {
                return "Fizz";
            }
            else {
                return num.ToString();
            }
        }

        public void FizzBuzz()
        {
            for (var i = 1; i <= this.upTo; ++i) {
                System.Console.WriteLine(this.NumToString(i));
            }
        }
    }
}
