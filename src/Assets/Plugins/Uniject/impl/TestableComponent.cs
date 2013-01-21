using System;
using System.Collections;

namespace Uniject {
    public class TestableComponent {
        private TestableGameObject obj;

        public bool enabled { get; set; }

        public TestableComponent(TestableGameObject obj) {
            this.enabled = true;
            this.obj = obj;
            obj.registerComponent(this);
        }

        public TestableGameObject Obj {
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
            obj.bridge.StartCoroutine ("CoroutineBridge", new object[] { this, name, args });
        }

        public void StartCoroutine(IEnumerator cr)
        {
            obj.bridge.StartCoroutine(cr); // TODO: Use a named method to kick this off so IEnumerator-based coroutines also stop when using StopCoroutines()
        }

        public void StopCoroutines()
        {
            obj.bridge.StopCoroutine("CoroutineBridge");
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

        public virtual void OnCollisionEnter(Collision collision)
        {
        }
    }
}

