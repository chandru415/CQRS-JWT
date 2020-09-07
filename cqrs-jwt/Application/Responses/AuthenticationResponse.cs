namespace Application.Responses
{
    public class AuthenticationResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string[] Errors { get; set; }
    }
}
