using System;

namespace Uniject
{
	public interface IUnityBridgeComponent : IComponent
	{
		void StartCoroutine(object _this, string coroutine, object[] args);
	}
}

