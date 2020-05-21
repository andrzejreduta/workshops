using Exercises._01_Types;

namespace Exercises._02_Generics
{
    public class Result<T>
    {
        public T Value { get; }
        public string Error { get; }
        public bool IsSuccessful { get; }

        public static Result<T> Success(T value) => new Result<T>(value, null, true);
        public static Result<T> Failure(string message) => new Result<T>(default, message, false);
        
        private Result(T value, string error, bool success)
        {
            Value = value;
            Error = error;
            IsSuccessful = success;
        }
    }

    public class Service
    {
        public void DoSth()
        {
            Result<Money>.Success(Money.Of(1, Currency.EUR));

        }
    }
}