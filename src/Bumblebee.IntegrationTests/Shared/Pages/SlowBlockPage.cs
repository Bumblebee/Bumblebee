using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
    public class SlowBlockPage : Page
    {
        public SlowBlockPage(Session session) : base(session)
        { }

        public SlowBlockWithNoWait CustomerInfoWithNoWait => new SlowBlockWithNoWait(this);
        public SlowBlockWithExplicitWait CustomerInfoWithExplicitWait => new SlowBlockWithExplicitWait(this);
    }

    public class SlowBlockWithNoWait : Block
    {
        public SlowBlockWithNoWait(IBlock parent) : base(parent, By.Id("customerInfo"))
        { }

        public ITextField FirstName => new TextField(this, By.Id("firstName"));
    }

    public class SlowBlockWithExplicitWait : Block
    {
        public SlowBlockWithExplicitWait(IBlock parent) : base(parent, By.Id("customerInfo"), TimeSpan.FromSeconds(10))
        { }

        public ITextField FirstName => new TextField(this, By.Id("firstName"));
    }
}
