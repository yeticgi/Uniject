using System;

namespace Uniject {
    public interface ISphereCollider : ICollider {
        float radius { get; set; }
        Vector3 center { get; set; }
    }
}

