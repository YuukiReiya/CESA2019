using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{

    public class OnSceneSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;
        public static T Instance { get { if (instance == null) { instance = FindObjectOfType<T>(); } return instance; } protected set { instance = value; } }

        private void Awake()
        {
            Instance = FindObjectOfType<T>();
        }

        private void Reset()
        {
            gameObject.name = GetType().Name;
        }
    }

}