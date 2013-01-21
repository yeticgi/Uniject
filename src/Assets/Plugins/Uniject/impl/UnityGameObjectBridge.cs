using System;
using System.Reflection;
using Uniject.Impl;
using UnityEngine;
using System.Collections;

public class UnityGameObjectBridge : MonoBehaviour {
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

    public void OnCollisionEnter(Collision c) {
        UnityGameObjectBridge other = c.gameObject.GetComponent<UnityGameObjectBridge>();
        if (null != other) {
                Uniject.Collision testableCollision =
                new Uniject.Collision(c.relativeVelocity,
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

