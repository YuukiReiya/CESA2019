using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DAGASIScripts
{
    public static class ImageExtension
    {

        public static void SetImageColorA(this Image img, float value)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, value);
        }

    }
}
