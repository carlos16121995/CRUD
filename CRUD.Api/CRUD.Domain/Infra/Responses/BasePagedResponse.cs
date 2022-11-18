using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace CRUD.Domain.Infra.Responses
{
    public class BaseResponse<TData> : BaseResponse
    {
        public virtual TData? Data { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(TData data, bool success = false, string message = "", HttpStatusCode? statusCode = null)
        {
            base.Success = success;
            base.Message = message;
            Data = data;
            base.StatusCode = statusCode;
        }
    }

    public class BasePagedResponse<TData> : BaseResponse
    {
        public IEnumerable<TData>? Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }

    public class BaseResponse
    {
        public string RequestId { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string ErrorDetails { get; set; } = "";


        [JsonIgnore]
        [NotMapped]
        public HttpStatusCode? StatusCode { get; set; }

        public IEnumerable<ErrorModel> Errors { get; set; } = new List<ErrorModel>();


        public bool IsError => !Success;

        public BaseResponse()
        {
            RequestId = string.Empty;
            Message = string.Empty;
            ErrorDetails = string.Empty;
        }

        public BaseResponse(bool success = false, string message = "", HttpStatusCode? statusCode = null)
        {
            RequestId = string.Empty;
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
    public class ErrorModel
    {
        public string? Property { get; set; }

        public IEnumerable<string>? Message { get; set; }
    }
}
