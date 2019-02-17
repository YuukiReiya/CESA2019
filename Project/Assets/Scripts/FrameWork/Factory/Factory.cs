using UnityEngine;
using System.Collections;

namespace DAGASIScripts
{
    public interface IFactory<T> { };

    public class Factory<T> : Singleton<Factory<T>>, IFactory<T> where T : MonoBehaviour
    {
        public virtual T Create(T o)
        {
            return Instantiate(o);
        }
        public virtual T Create(T o, Vector3 position, Quaternion rotation)
        {
            return Instantiate(o, position, rotation);
        }
        public virtual T Create(T o, Transform parent, bool worldPositionStays)
        {
            return Instantiate(o, parent, worldPositionStays);
        }
        public virtual T Create(T o, Transform parent)
        {
            return Instantiate(o, parent);
        }
        public virtual T Create(T o, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Instantiate(o, position, rotation, parent);
        }
    }
    public abstract class SimpleFactory<T> : Singleton<SimpleFactory<T>>, IFactory<T> where T : MonoBehaviour
    {
        public virtual T Create()
        {
            return Instantiate(GetPrefab());
        }
        public virtual T Create(Vector3 position, Quaternion rotation)
        {
            return Instantiate(GetPrefab(), position, rotation);
        }
        public virtual T Create(Transform parent, bool worldPositionStays)
        {
            return Instantiate(GetPrefab(), parent, worldPositionStays);
        }
        public virtual T Create(Transform parent)
        {
            return Instantiate(GetPrefab(), parent);
        }
        public virtual T Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            return Instantiate(GetPrefab(), position, rotation, parent);
        }
        public virtual T[] Create(int size)
        {
            T[] ts = new T[size];
            for (int i = 0; i < size; i++)
            {
                ts[i] = Create();
            }
            return ts;
        }
        public virtual T[] Create(int size, Transform parent)
        {
            T[] ts = new T[size];
            for (int i = 0; i < size; i++)
            {
                ts[i] = Create(parent);
            }
            return ts;
        }
        public virtual T[] Create(int size, Transform parent, bool worldPositionStays)
        {
            T[] ts = new T[size];
            for (int i = 0; i < size; i++)
            {
                ts[i] = Create(parent, worldPositionStays);
            }
            return ts;
        }

        public abstract T GetPrefab();
    }
}