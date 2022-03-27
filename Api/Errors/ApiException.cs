namespace Api.Errors
{
    public class ApiException : ApiResponses
    {
        public ApiException(int Statuscode, string? message = null , string details = null ) : base(Statuscode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
