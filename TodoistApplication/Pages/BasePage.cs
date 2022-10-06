using CommonLibs.Implementation;

namespace TodoistApplication.Pages
{
    public class BasePage
    {
        public CommonElement cmnElement;

        public BasePage()
        {
            cmnElement = new CommonElement();
        }
    }
}