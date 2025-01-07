namespace AdventureApp.Models.ReponseDtos
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public int StatusCode { get; set; } // HTTP STATUS
        public List<string>? Errors { get; set; } // ERROR STATUS
    }
}
