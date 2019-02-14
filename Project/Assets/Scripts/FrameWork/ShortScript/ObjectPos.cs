using UnityEngine;
namespace DAGASIScripts
{
    /// <summary>
    /// 追従
    /// </summary>
    public class ObjectPos : MonoBehaviour
    {

        [SerializeField]
        GameObject baseObj;
        [SerializeField]
        Vector3 addPos;
        [SerializeField]
        Vector3 rotate;

        // Use this for initialization
        void Start()
        {
            transform.eulerAngles = rotate;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = baseObj.transform.position + addPos;
        }
    }

}