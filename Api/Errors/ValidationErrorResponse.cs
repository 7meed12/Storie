namespace Api.Errors
{
    public class ValidationErrorResponse : ApiResponses
    {
        public ValidationErrorResponse() : base(400)
        {
            
    }
        public IEnumerable<string> Errors { get; set; }
    }
}
