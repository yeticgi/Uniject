using System;

namespace Uniject
{
	public interface IUnityBridgeComponent : IComponent
	{
		void StartCoroutine(string coroutine, object _this, object[] args);
	}
}

