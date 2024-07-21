
using System.Net;
using BlogApi.src.Models;

namespace BlogApi.src.Helpers
{
    public static class ApiResponseHelper
    {
        public static ApiResponse SuccessResponse<T>(string message, T data, HttpStatusCode statusCode = HttpStatusCode.OK )
        {
            return new ApiResponse
            {
                Status = true,
                StatusCode = statusCode,
                Data = data,
                Message = [message ?? ""] 
            };
        }

        public static ApiResponse ErrorResponse(string ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResponse
            {
                Status = false,
                StatusCode = statusCode,
                Data = default,
                Message = [ex ?? ""]
            };
        }
    }
    public class HttpStatusCodeException(HttpStatusCode statusCode, string message) : Exception(message)
{
        public HttpStatusCode StatusCode { get; } = statusCode;
    }

    }
