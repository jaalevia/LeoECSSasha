using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct EcsMoverComponent
    {
        public float Speed;
        public Transform Anchor;
        public float Amplitude;
        public float StartZ;
    }
}