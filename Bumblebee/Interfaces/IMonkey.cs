using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Bumblebee.Interfaces
{
    public interface IMonkey
    {
        double Probability { get; set; }
        void Invoke(IBlock block);
        IList<string> Logs { get; } 
        void VerifyState();
    }
}
