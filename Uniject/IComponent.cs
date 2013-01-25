using System;
using System.Collections;

namespace Uniject
{
	public interface IComponent
	{
    	IGameObject GameObject { get; }
		void Awake();
		void Update();
		void OnGUI();
		void CollisionEnter(ICollision collision);
		void StartCoroutine(string coroutine, params object[] args);
		void StartCoroutine(IEnumerator coroutine);
		void StartCoroutine(string coroutine);
		void StopCoroutines();
		void StopCoroutine(string coroutine);
	}
}

