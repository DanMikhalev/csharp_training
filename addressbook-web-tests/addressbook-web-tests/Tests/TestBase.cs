using NUnit.Framework;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int maxLength)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * maxLength);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 65) + 32));
            }
            return builder.ToString();
        }

        public static string GenerateRandomNumberString(int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 9)));
            }
            return builder.ToString();
        }
    }
}
