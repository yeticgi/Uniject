using UnityEngine;
using System.Linq;

namespace Uniject.Unity
{
    public class UnityScreen : IScreen
    {
        public void SetResolution(int width, int height, bool fullscreen) { Screen.SetResolution(width, height, fullscreen); }
        public void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate) { Screen.SetResolution(width, height, fullscreen, preferredRefreshRate); }

        public bool autorotateToLandscapeLeft { get { return Screen.autorotateToLandscapeLeft; } set { Screen.autorotateToLandscapeLeft = value; } }
        public bool autorotateToLandscapeRight { get { return Screen.autorotateToLandscapeRight; } set { Screen.autorotateToLandscapeRight = value; } }
        public bool autorotateToPortrait { get { return Screen.autorotateToPortrait; } set { Screen.autorotateToPortrait = value; } }
        public bool autorotateToPortraitUpsideDown { get { return Screen.autorotateToPortraitUpsideDown; } set { Screen.autorotateToPortraitUpsideDown = value; } }
        public Resolution currentResolution { get { return Screen.currentResolution.ToUniject(); } }
        public float dpi { get { return Screen.dpi; } }
        public bool fullScreen { get { return Screen.fullScreen; } set { Screen.fullScreen = value; } }
        public Resolution[] GetResolution { get { return Screen.GetResolution.Select(r => r.ToUniject()).ToArray(); } }
        public int height { get { return Screen.height; } }
        public bool lockCursor { get { return Screen.lockCursor; } set { Screen.lockCursor = value; } }
        public ScreenOrientation orientation { get { return (ScreenOrientation)Screen.orientation; } set { Screen.orientation = (UnityEngine.ScreenOrientation)value; } }
        public Resolution[] resolutions { get { return Screen.resolutions.Select(r => r.ToUniject()).ToArray(); } }
        public bool showCursor { get { return Screen.showCursor; } set { Screen.showCursor = value; } }
        public int sleepTimeout { get { return Screen.sleepTimeout; } set { Screen.sleepTimeout = value; } }
        public int width { get { return Screen.width; } }
    }
}