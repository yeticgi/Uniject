using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniject.Impl {
    public class UnityTime : ITime {

        public float DeltaTime {
            get { return Time.deltaTime; }
        }

		public float FixedDeltaTime {
			get { return Time.fixedDeltaTime; }
		}
       
        public float RealTimeSinceStartup {
            get { return Time.realtimeSinceStartup; }
        }
    }
}
