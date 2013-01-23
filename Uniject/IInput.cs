using System;

namespace Uniject {

    /// <summary>
    /// Extracted from UnityEngine.Input.
    /// </summary>
    public interface IInput {
        Vector3 mousePosition { get; }
        bool anyKey { get; }
        bool anyKeyDown { get; }
        string inputString { get; }
        Vector3 acceleration { get; }
        IAccelerationEvent[] accelerationEvents { get; }
        int accelerationEventCount { get; }
        ITouch[] touches { get; }
        int touchCount { get; }
        bool multiTouchEnabled { get; }

        float GetAxis(string name);
        float GetAxisRaw(string name);
        bool GetButton(string name);
        bool GetButtonDown(string name);
        bool GetButtonUp(string name);
        bool GetKey(string name);
        bool GetKeyDown(string name);
        bool GetKeyUp(string name);
        string[] GetJoystickNames();
        bool GetMouseButton(int button);
        bool GetMouseButtonDown(int button);
        bool GetMouseButtonUp(int button);
        void ResetInputAxes();
        IAccelerationEvent GetAccelerationEvent(int index);
        ITouch GetTouch(int index);
    }
}

