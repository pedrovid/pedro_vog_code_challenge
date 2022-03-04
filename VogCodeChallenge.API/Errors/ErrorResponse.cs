namespace VogCodeChallenge.API.Errors
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; private set; }

        public ErrorResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
