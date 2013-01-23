using System;
using System.Collections;

namespace Uniject
{
	public interface IComponent
	{
		void Awake();
		void Update();
		void OnGUI();
		void OnCollisionEnter(ICollision collision);
		void StartCoroutine(string coroutine, params object[] args);
		void StartCoroutine(IEnumerator coroutine);
		void StartCoroutine(string coroutine);
		void StopCoroutines();
		void StopCoroutine(string coroutine);
	}
}

