using System;

namespace Uniject
{
	public interface IGameObject
	{
		IComponent Bridge { get; }
		void RegisterComponent(IComponent component);
	}
}

