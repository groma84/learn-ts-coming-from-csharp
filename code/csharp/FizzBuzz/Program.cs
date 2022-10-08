// See https://aka.ms/new-console-template for more information

using FizzBuzz;

var fb = new FizzBuzz.FizzBuzzer(100);
fb.FizzBuzz();

var ts = new List<ITransaction>() {
    new Transaction(-7),
    new Transaction(36),
    new Transaction(6),
};
System.Console.WriteLine(Workflow.ToPrintableOnlyPositive(ts));

var result = FizzBuzz.Examples.Map<String, int>("abc", (String s) => s.Length);
var result_ = FizzBuzz.Examples.Map("abc", s => s.Length);

public enum Direction
{
    Up,
    Down,
}

public enum UserResponse
{
    No = 0,
    Yes = 1,
}






