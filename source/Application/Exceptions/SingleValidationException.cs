using FluentValidation.Results;

namespace Application.Exceptions
{
    public class SingleValidationException : Exception
    {
        public SingleValidationException()
            : base("خطایی در اعتبار سنجی ورودی ها رخ داده است")
        {
            Error = "";
        }

        public SingleValidationException(ValidationFailure failure)
            : this()
        {
            Error = failure.ErrorMessage;
        }

        public string Error { get; }
    }
}
