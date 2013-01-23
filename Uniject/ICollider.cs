using System;

namespace Uniject {
    public interface ICollider {
        bool enabled { get; set; }
        IPhysicsMaterial material { get; set; }
    }
}

