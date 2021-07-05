using System;

namespace Internship.Core
{
	public interface IUnitOfWork : IDisposable
	{
		int Complete();
	}
}
