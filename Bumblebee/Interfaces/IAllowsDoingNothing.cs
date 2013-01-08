using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bumblebee.Interfaces
{
    public interface IAllowsNoOp
    {
        TCustomResult Then<TCustomResult>() where TCustomResult : IBlock;
    }

    public interface IAllowsNoOp<out TResult> : IAllowsNoOp where TResult : IBlock
    {
        TResult Then();
    }
}
