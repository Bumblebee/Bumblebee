using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
