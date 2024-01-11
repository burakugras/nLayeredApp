namespace Core.CrossCuttinConcerns.Exceptions.Types
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message) : base(message)
        {

        }
    }
}
