using System.Net;

namespace Elasticsearch.API.DTOs
{
    public record ResponseDTO<T>
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
        public HttpStatusCode Status { get; set; }

        public static ResponseDTO<T> Succes(T data, HttpStatusCode status)
        {
            return new ResponseDTO<T> { Data = data, Status = status };
        }

        public static ResponseDTO<T> Fail(List<string> errors, HttpStatusCode status)
        {
            return new ResponseDTO<T> { Errors = errors, Status = status };
        }
    }
}
