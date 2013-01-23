using Ninject;
using System;
using Uniject;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Uniject.Unity
{
	/// <summary>
	/// A <c>Provider</c> that instantiates Unity prefabs wrapped as <c>TestableGameObject</c>.
	/// </summary>
	public class PrefabProvider : Ninject.Activation.Provider<IGameObject> {

	    private IResourceLoader loader;

	    public PrefabProvider(IResourceLoader loader) {
	        this.loader = loader;
	    }

	    protected override IGameObject CreateInstance(Ninject.Activation.IContext context)
	    {
	        ResourceAttribute attrib = (ResourceAttribute)context.Request.Target.GetCustomAttributes(typeof(ResourceAttribute), false).FirstOrDefault();
	        if (attrib == null)
	        {
	            return new UnityGameObject(new GameObject());
	        }
	        return loader.instantiate(attrib.Path);
	    }
	}
}
