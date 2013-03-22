using System;

namespace Uniject
{
	public interface IGameObject
	{
		IUnityBridgeComponent Bridge { get; }
        void Destroy();
		void RegisterComponent(IComponent component);
		T GetComponent<T>() where T : class;
		T[] GetComponentsInChildren<T>() where T : class;
		T GetComponentInChildren<T>() where T : class;
		ITransform Transform { get; }
		string Name { get; set; }
		void DontDestroyOnLoad();
		bool Active { get; set; }
	}
}

