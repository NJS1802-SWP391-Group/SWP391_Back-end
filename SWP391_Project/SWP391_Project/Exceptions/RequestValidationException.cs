using Microsoft.AspNetCore.Mvc;

namespace SWP391_Project.Exceptions
{
    public class RequestValidationException : Exception
    {
        public ValidationProblemDetails ProblemDetails { get; set; }
        public RequestValidationException(ValidationProblemDetails details)
        {
            ProblemDetails = details;
        }
    }
}
