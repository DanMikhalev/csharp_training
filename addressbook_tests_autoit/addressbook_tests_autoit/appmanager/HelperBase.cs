using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 Aux; 
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.WINTITLE = ApplicationManager.WINTITLE;
            Aux = manager.Aux;
        }
    }
}