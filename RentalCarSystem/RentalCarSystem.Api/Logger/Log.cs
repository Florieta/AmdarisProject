﻿using System.Text;

namespace RentalCarSystem.Api.Logger
{
    public sealed class Log : ILog
    {
        private Log()
        {

        }

        private static readonly Lazy<Log> instance = new Lazy<Log>();

        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        public void LogExceptions(string message)
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
    }
}
