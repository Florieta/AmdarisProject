using RentACar.WebApi.Middleware;
using System.Text;


namespace RentACar.Api.Logger
{
    public sealed class Log
    {
        private static Log instance = null!;
        private static readonly object padlock = new object();
        private Log()
        {

        }

        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Log();
                        }


                    }
                }
                return instance;
            }
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }


        public void LogWarning(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Warning", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.Append("[Warning]");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LogInformation(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Information", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.Append("[Info]");
            sb.Append(DateTime.Now.ToShortTimeString() + " ");
            sb.Append(message);

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(sb.ToString());
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
