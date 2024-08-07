﻿using System.Net;

namespace SWP391_Project.Common.Responses;
public class StatusCodeResponse<T>
{
    public T Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public object? BonusData { get; set; }
}
