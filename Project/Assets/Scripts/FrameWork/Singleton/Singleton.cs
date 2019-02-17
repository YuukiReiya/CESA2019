using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAGASIScripts
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        static T instance;
        public static T Instance { get { if (instance == null) { instance = FindObjectOfType<T>(); } return instance; } protected set { instance = value; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void Reset()
        {
            gameObject.name = typeof(T).Name;
        }
    }

    public static class Singleton2<T> where T : MonoBehaviour
    {
        static T instance;
        public static T Instance { get { if (instance == null) { instance = GameObject.FindObjectOfType<T>(); GameObject.DontDestroyOnLoad(instance); } return instance; } private set { instance = value; } }
    }
}
