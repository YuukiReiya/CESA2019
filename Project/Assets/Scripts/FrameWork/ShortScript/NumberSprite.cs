using UnityEngine;
using UnityEngine.UI;
namespace DAGASIScripts
{

    /// <summary>
    /// 数値の画像の配列
    /// </summary>
    public class NumberSprite : MonoBehaviour
    {

        [SerializeField]
        Sprite[] number = new Sprite[10];

        public Sprite GetNumber(int num)
        {
            return number[num];
        }
        public void SetNumber(Image[] images, int value)
        {
            foreach (var v in images)
            {
                v.gameObject.SetActive(false);
            }
            images[0].gameObject.SetActive(true);
            images[0].sprite = GetNumber(0);

            int[] vs = value.GetNumbers();
            for (int i = 0; i < vs.Length; i++)
            {
                images[i].gameObject.SetActive(true);
                images[i].sprite = GetNumber(vs[i]);
            }
        }
    } 
}
