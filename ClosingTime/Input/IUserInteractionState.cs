using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosingTime.Input
{
	public interface IUserInteractionState
	{
		void Setup();
		void Activity(); 
		void Teardown();
	}
}
