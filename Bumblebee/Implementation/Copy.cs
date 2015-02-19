using System;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
    [Obsolete("Make a string property instead that directly returns the text. Do verifications through a lambda on the parent block.")]
    public class Copy<TResult> : SpecificBlock, ICopy<TResult> where TResult : IBlock
    {
        public Copy(IBlock parent, By by) : base(parent, by)
        {
        }
    }
}
