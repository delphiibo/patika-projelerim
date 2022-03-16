using System;

namespace arayuzler
{
    public class SmsLogger : ILogger
    {
        public void writeLog()
        {
            Console.WriteLine("Sms olarak yazar.");
        }
    }
}
