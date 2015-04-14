using System.Collections.Generic;

namespace Bumblebee.Interfaces
{
	public interface IMonkey
	{
		void Invoke(IBlock block);
		IList<string> Logs { get; }
		void VerifyState();
	}
}
