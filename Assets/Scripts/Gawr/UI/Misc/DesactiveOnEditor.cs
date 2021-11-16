using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gawr.UI.Misc
{
    public class DesactiveOnEditor : MonoBehaviour
    {
        public GameObject ToDeactive;
        private void Awake()
        {
            if (Application.isEditor)
            {
                ToDeactive.SetActive(false);
            }
        }
    }
}