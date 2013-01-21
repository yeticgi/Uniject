using System;
using Ninject;
using Ninject.Injection;
using Ninject.Parameters;
using UnityEngine;
using System.Linq;

public class UnityInjector
{
    private static IKernel kernel;
    private static GameObject listener;
    public static IKernel get()
    {
        if (null == kernel)
        {
            kernel = new StandardKernel(new UnityNinjectSettings(), new Ninject.Modules.INinjectModule[] {
                new UnityModule()
            });
            if (listener == null)
            {
                listener = new GameObject();
                listener.name = "LevelLoadListener";
                listener.AddComponent<LevelLoadListener>();
            }
        }
        return kernel;
    }

    private static object _levelScope;
    public static object levelScope {
        get { return _levelScope; }
        set { _levelScope = value; }
    }

    private static object scoper(Ninject.Activation.IContext context) {
        return levelScope;
    }
}

