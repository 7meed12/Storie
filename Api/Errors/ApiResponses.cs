namespace Api.Errors
{
    public class ApiResponses
    {
        public ApiResponses(int Statuscode , string? message = null)
        {
          StatusCode = Statuscode  ;
            Message = message ?? GetDefaultMessage(Statuscode);
        }

        

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string? GetDefaultMessage(int statuscode)
        {
            return statuscode switch
            {
                
                400 => "A Bad Request has been made",
                401 => "Authorized",
                404 => "Resource not found",
                500 => "Error",
                _ => null
            };
        }
    }
}
