using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinimalisticTelnet;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }

        public void Add(AccountData account)
        {
            if (Verify(account)) return;
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            System.Console.Out.Write(telnet.Read());
        }
        public void Delete(AccountData account)
        {
            if (!Verify(account)) return;
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);
            System.Console.Out.Write(telnet.Read());
        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.Write(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.Write(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.Write(telnet.Read());
            return telnet;
        }

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify " + account.Name);
            string s = telnet.Read();
            System.Console.Out.WriteLine(s);
            return !s.Contains("does not exist");
        }
    }
}
