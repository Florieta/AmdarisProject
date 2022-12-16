namespace RentACar.Api.Logger
{
    public interface ILog<ExceptionMiddleWare>
    {
        void LogExceptions(string message);
        void LogInformation(string message);
        void LogWarning(string message);
    }
}
