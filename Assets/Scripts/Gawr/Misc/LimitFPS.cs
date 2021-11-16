using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gawr.Misc
{
    public class LimitFPS : MonoBehaviour
    {
        [SerializeField] private int _FPS;

        private void Awake()
        {
            Application.targetFrameRate = _FPS;
        }
    }
}
