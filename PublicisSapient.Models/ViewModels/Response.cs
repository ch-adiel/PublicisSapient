using System.Text.Json;

namespace PublicisSapient.Models.ViewModels
{
    public class Response<T>
    {
        public Response()
        {
            Status = false;
            StatusCode = 400;
            Data = default;
            Message = "Something went wrong.";
        }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
