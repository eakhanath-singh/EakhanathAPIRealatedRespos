using Program01.InterfaceClass;

namespace Program01.BusinessLogic
{
    public class LogInfo : ILogInfo
    {
        private readonly Guid _instanceId;

        public LogInfo()
        {
            _instanceId = Guid.NewGuid();
            Console.WriteLine($"LoggerService instance created: {_instanceId}");
        }

        public void LogDetails(string message)
        {
            // Log the message to a file or database
            Console.WriteLine($" {_instanceId} Log: {message}");
        }   
    }
}
