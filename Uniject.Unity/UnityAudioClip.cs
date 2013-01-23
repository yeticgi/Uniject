using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class UnityAudioClip : IAudioClip
	{
		public readonly AudioClip AudioClip;

		public UnityAudioClip (AudioClip audioClip)
		{
			this.AudioClip = audioClip;
		}
	}
}

