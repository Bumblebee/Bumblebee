using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class SpecificBlock : Block
    {
        protected SpecificBlock(Session session, IWebElement dom) : base(session)
        {
            Dom = dom;
        }
    }
}
