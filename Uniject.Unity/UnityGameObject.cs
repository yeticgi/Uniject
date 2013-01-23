using System.Collections.Generic;
using System;
using UnityEngine;
using Uniject;
using System.Linq;

namespace Uniject.Unity {
    public class UnityGameObject : IGameObject
	{
		private List<IComponent> components = new List<IComponent>();
		
		public IComponent Bridge { get { return bridge; } }
		private UnityBridgeComponent bridge;
		
		public ITransform transform { get; private set; }

		private GameObject obj;

		public UnityGameObject(GameObject obj)
		{
			this.obj = obj;
			this.bridge = obj.AddComponent<UnityBridgeComponent>();
			this.bridge.wrapping = this;
			this.transform = obj.transform.ToUniject();
		}
		
		public void RegisterComponent(IComponent component) {
			components.Add(component);
			component.Awake();
		}
		
		public bool destroyed { get; private set; }
		
		public void Update() {
			if (active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.Update();
				}
			}
		}
		
		public void OnGUI() {
			if (active) {
				for (int t = 0; t < components.Count; t++) {
					IComponent component = components[t];
					component.OnGUI();
				}
			}
		}
		
		public IEnumerable<IComponent> getComponents()
		{
			return components;
		}
		
		public void OnCollisionEnter(Collision c) {
			for (int t = 0; t < components.Count; t++) {
				components[t].OnCollisionEnter(c);
			}
		}

        public void Destroy() {
			if (!destroyed) {
				foreach (UnityComponent component in this.components) {
					component.OnDestroy();
				}
				destroyed = true;
			}
            GameObject.Destroy (this.obj);
        }

        public bool active {
            get { return obj.active; }
            set { obj.active = value; }
        }

        public string name {
            get { return obj.name; }
            set { obj.name = value; }
        }

        public void setActiveRecursively(bool active) {
            obj.SetActiveRecursively(active);
        }

        public T getComponent<T>() where T : class
        {
			for (int t = 0; t < components.Count; t++) {
				IComponent component = components[t];
				if (component is T) {
					return component as T;
				}
			}

            if (obj != null)
            {
                var component = obj.GetComponents(typeof(T)).FirstOrDefault() as T;
                
                if (component != null)
                {
                    return component;
                }
            }

            return null;
        }


        public int layer {
            get { return obj.layer; }
            set { obj.layer = value; }
        }
    }
}
