using System;
using System.Collections;

namespace Uniject.Unity
{
    public class UnityComponent : IComponent
	{
        private IGameObject obj;

        public bool enabled { get; set; }

        public UnityComponent(IGameObject obj) {
            this.enabled = true;
            this.obj = obj;
            obj.RegisterComponent(this);
        }

        public IGameObject Obj {
            get { return obj; }
            set { obj = value; }
        }

        public void OnUpdate() {
            if (enabled) {
                Update();
            }
        }

        public void StartCoroutine(string name, params object[] args)
        {
            obj.Bridge.StartCoroutine ("CoroutineBridge", new object[] { this, name, args });
        }

		public void StartCoroutine (string coroutine)
		{
			obj.Bridge.StartCoroutine(coroutine);
		}

        public void StartCoroutine(IEnumerator coroutine)
        {
            obj.Bridge.StartCoroutine(coroutine); // TODO: Use a named method to kick this off so IEnumerator-based coroutines also stop when using StopCoroutines()
        }

        public void StopCoroutines()
        {
            obj.Bridge.StopCoroutine("CoroutineBridge");
        }

		public void StopCoroutine(string coroutine)
		{
			obj.Bridge.StopCoroutine(coroutine);
		}

        public virtual void Awake()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnDestroy()
        {
        }

        public virtual void OnGUI()
        {
        }

        public virtual void OnCollisionEnter(ICollision collision)
        {
        }
    }
}

