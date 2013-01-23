using System;

namespace Uniject {
    public interface IAudioSource {
        void Play();
        void loopSound(IAudioClip clip);
        void playOneShot(IAudioClip clip);

        bool isPlaying { get; }
    }

}
