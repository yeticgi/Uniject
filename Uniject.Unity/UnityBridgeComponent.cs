using System;
using System.Reflection;
using Uniject.Impl;
using UnityEngine;
using System.Collections;

namespace Uniject.Unity
{
	public class UnityBridgeComponent : MonoBehaviour, IComponent
	{
		public void Awake()
		{
		}

	    public void OnDestroy() {
	        wrapping.Destroy();
	    }

	    public void Update() {
	        wrapping.Update();
	    }

	    public void OnGUI()
	    {
	        wrapping.OnGUI();
	    }

		public void OnCollisionEnter(ICollision collision)
		{
		}

		void IComponent.StartCoroutine(string name, params object[] args)
		{
			base.StartCoroutine("CoroutineBridge", new object[] { this, name, args });
		}

		void IComponent.StartCoroutine (IEnumerator coroutine)
		{
			base.StartCoroutine(coroutine);
		}

		void IComponent.StartCoroutine (string coroutine)
		{
			base.StartCoroutine(coroutine);
		}

		void IComponent.StopCoroutines()
		{
			base.StopAllCoroutines();
		}

		void IComponent.StopCoroutine(string coroutine)
		{
			base.StopCoroutine(coroutine);
		}

	    public void OnCollisionEnter(UnityEngine.Collision c) {
	        UnityBridgeComponent other = c.gameObject.GetComponent<UnityBridgeComponent>();
	        if (null != other) {
	                Collision testableCollision = new Collision(c.relativeVelocity.ToUniject(),
				                                            other.wrapping.transform,
				                                            other.wrapping,
				                                            c.contacts);
	            wrapping.OnCollisionEnter(testableCollision);
	        }
	    }

	    public IEnumerator CoroutineBridge (object[] packedArgs)
	    {
	        object _this = packedArgs[0];
	        string coroutineName = packedArgs[1] as string;
	        object[] args = packedArgs[2] as object[];
	        return _this.GetType ().InvokeMember(coroutineName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic, null, _this, args) as IEnumerator;
	    }

	    public UnityGameObject wrapping;
	}
}
