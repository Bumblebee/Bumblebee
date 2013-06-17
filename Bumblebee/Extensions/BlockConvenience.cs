using System;
using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
    public static class BlockConvenience
    {
        public static TScope ScopeTo<TScope>(this IBlock block) where TScope : IBlock
        {
            return block.Session.CurrentBlock<TScope>();
        }

        [Obsolete("There's no need to use this. If you need to change scope you can do it with ScopeTo<>.")]
        public static TScope ScopeToParent<TScope>(this IAllowsNoOp<TScope> block) where TScope : IBlock
        {
            return block.Session.CurrentBlock<TScope>();
        }
    }
}
