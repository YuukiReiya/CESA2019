using UnityEngine;
namespace DAGASIScripts
{

    /// <summary>
    /// Spriteの配列
    /// </summary>
    public class Sprites : MonoBehaviour
    {

        public Sprite this[int value] { get { return sprites[value]; } }
        public int Length { get { return sprites.Length; } }

        [SerializeField]
        Sprite[] sprites;
    }

}