using System;

namespace Uniject.Unity
{
	public static class ToUnityExtensions
	{
		public static UnityEngine.Vector3 ToUnity(this Vector3 v)
		{
			return new UnityEngine.Vector3(v.X, v.Y, v.Z);
		}

		public static UnityEngine.Quaternion ToUnity(this Quaternion q)
		{
			return new UnityEngine.Quaternion(q.X, q.Y, q.Z, q.W);
		}

		public static UnityEngine.AudioClip ToUnity(this IAudioClip c)
		{
			return (c as UnityAudioClip).AudioClip;
		}

		public static UnityEngine.Color ToUnity(this Color c)
		{
			return new UnityEngine.Color(c.R, c.G, c.B, c.A);
		}
	}
}

