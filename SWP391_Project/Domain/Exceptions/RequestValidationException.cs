﻿using Microsoft.AspNetCore.Mvc;

namespace Domain.Exceptions
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
