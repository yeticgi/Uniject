using System;
using UnityEngine;

namespace Uniject.Unity
{
    public class UnityAudioListener : UnityComponent, IAudioListener {

        public UnityAudioListener(IGameObject parent, GameObject obj) : base(parent) {
            AudioListener listener = obj.GetComponent<AudioListener>();
            if (null == listener) {
                obj.AddComponent<AudioListener>();
            }
        }

        public void noOp() {
        }
    }
}

