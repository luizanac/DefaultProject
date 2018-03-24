using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefaultProject.Shared.Commands
{
	public interface ICommandHandler<T, TR> : ICommand 
	{
		Task<TR> Handle(T command);
	}
}