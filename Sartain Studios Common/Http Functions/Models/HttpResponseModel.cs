namespace Sartain_Studios_Common.Http_Functions.Models
{
    public class HttpResponseModel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string TraceId { get; set; }
    }
}