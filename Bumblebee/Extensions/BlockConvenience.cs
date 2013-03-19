using Bumblebee.Interfaces;

namespace Bumblebee.Extensions
{
    public static class BlockConvenience
    {
        public static TScope ScopeTo<TScope>(this IBlock block) where TScope : IBlock
        {
            return block.Session.CurrentBlock<TScope>();
        }

        public static TScope ScopeToParent<TScope>(this IAllowsNoOp<TScope> block) where TScope : IBlock
        {
            return block.Session.CurrentBlock<TScope>();
        }
    }
}
