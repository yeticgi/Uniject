using System;

namespace Uniject
{
	public interface IGameObject
	{
		IComponent Bridge { get; }
		void RegisterComponent(IComponent component);
		T GetComponent<T>() where T : class;
		T[] GetComponentsInChildren<T>() where T : class;
		T GetComponentInChildren<T>() where T : class;
		ITransform Transform { get; }
		string Name { get; set; }
		void DontDestroyOnLoad();
	}
}

