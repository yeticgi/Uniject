using System;
using Uniject;
using UnityEngine;

namespace Uniject.Unity
{
    public class UnityAudioSource : IAudioSource {
    	private AudioSource source;
    	public UnityAudioSource(GameObject obj) {
            this.source = obj.GetComponent<AudioSource>();
            if (this.source == null) {
                this.source = (AudioSource)obj.AddComponent(typeof(AudioSource));
            }
            source.rolloffMode = AudioRolloffMode.Linear;
    	}

        public void loopSound(IAudioClip clip) {
            source.loop = true;
            source.clip = clip.ToUnity();
            source.Play();
        }

        public void playOneShot(IAudioClip clip) {
            source.PlayOneShot(clip.ToUnity());
        }

    	public void Play ()
    	{
    		source.Play();
    	}

        public bool isPlaying {
            get { return source.isPlaying; }
        }
    }
}
