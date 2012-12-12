using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    public abstract class SpecificBlock : Block, ISpecificBlock
    {
        protected SpecificBlock(Session session, IWebElement tag) : base(session)
        {
            Tag = tag;
        }
    }
}
