namespace Contracts
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
    }
}
