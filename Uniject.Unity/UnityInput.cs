using System;
using UnityEngine;
using System.Linq;

namespace Uniject.Unity
{
    public class UnityInput : IInput {
        public Vector3 mousePosition { get { return Input.mousePosition.ToUniject(); } }
        public bool anyKey { get { return Input.anyKey; } }
        public bool anyKeyDown { get { return Input.anyKeyDown; } }
        public string inputString { get { return Input.inputString; } }
        public Vector3 acceleration { get { return Input.acceleration.ToUniject(); } }
        public IAccelerationEvent[] accelerationEvents { get { return Input.accelerationEvents.Select(e => e.ToUniject()).ToArray(); } }
        public int accelerationEventCount { get { return Input.accelerationEventCount; } }
        public ITouch[] touches { get { return Input.touches.Select(t => t.ToUniject()).ToArray(); } }
        public int touchCount { get { return Input.touchCount; } }
        public bool multiTouchEnabled { get { return Input.multiTouchEnabled; } }

        public float GetAxis(string name) { return Input.GetAxis(name); }
        public float GetAxisRaw(string name) { return Input.GetAxisRaw(name); }
        public bool GetButton(string name) { return Input.GetButton(name); }
        public bool GetButtonDown(string name) { return Input.GetButtonDown(name); }
        public bool GetButtonUp(string name) { return Input.GetButtonUp(name); }
        public bool GetKey(string name) { return Input.GetKey(name); }
        public bool GetKeyDown(string name) { return Input.GetKeyDown(name); }
        public bool GetKeyUp(string name) { return Input.GetKeyUp(name); }
        public string[] GetJoystickNames() { return Input.GetJoystickNames(); }
        public bool GetMouseButton(int button) { return Input.GetMouseButton(button); }
        public bool GetMouseButtonDown(int button) { return Input.GetMouseButtonDown(button); }
        public bool GetMouseButtonUp(int button) { return Input.GetMouseButtonUp(button); }
        public void ResetInputAxes() { Input.ResetInputAxes(); }
        public IAccelerationEvent GetAccelerationEvent(int index) { return Input.GetAccelerationEvent(index).ToUniject(); }
        public ITouch GetTouch(int index) { return Input.GetTouch(index).ToUniject(); }
    }
}

