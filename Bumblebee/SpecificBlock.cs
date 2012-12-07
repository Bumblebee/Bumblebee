using OpenQA.Selenium;

namespace Bumblebee
{
    public abstract class SpecificBlock : Block
    {
        protected SpecificBlock(Session session, IWebElement tag) : base(session)
        {
            Tag = tag;
        }
    }
}
