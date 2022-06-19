using System;
using UnityEngine;

namespace UnityTools
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _coolDown;
        private float cdLeft;

        public bool isReady => cdLeft < 0;
        public float left => cdLeft;

        public void UpdateTimer(float time = -1)
        {
            if (time == -1) time = Time.deltaTime;
            cdLeft -= time;
        }

        public void Reset()
        {
            cdLeft = _coolDown;
        }

        public void Reset(float newCD)
        {
            _coolDown = newCD;
            Reset();
        }

        public void End()
        {
            cdLeft = 0;
        }

        public Timer(float cd)
        {
            _coolDown = cd;
        }
    }
}