using System;
using UnityEngine;

namespace Uniject.Unity
{
	public class UnityAccelerationEvent : IAccelerationEvent
	{
		public readonly AccelerationEvent AccelerationEvent;

		public UnityAccelerationEvent(AccelerationEvent accelerationEvent)
		{
			this.AccelerationEvent = accelerationEvent;
		}
	}

}

