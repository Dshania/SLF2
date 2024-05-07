using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ClothesColour : MonoBehaviour, IPointerClickHandler
{
    public Color output;
    ClothesSelect cs;

    public void OnPointerClick(PointerEventData eventData)
    {
        output = Pick(Camera.main.WorldToScreenPoint(eventData.position), GetComponent<Image>());
    }

    public Color Pick(Vector2 screenPoint, Image imageToPick)
    {
        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageToPick.rectTransform, screenPoint, Camera.main, out point);
        point += imageToPick.rectTransform.sizeDelta / 2;
        Texture2D t = GetComponent<Image>().sprite.texture;
        Vector2Int mainPoint = new Vector2Int((int)((t.width * point.x) / imageToPick.rectTransform.sizeDelta.x),
            (int)((t.height * point.y) / imageToPick.rectTransform.sizeDelta.y));
        return t.GetPixel(mainPoint.x, mainPoint.y);
    }

    public void Update()
    {
  /*     GameObject[] clothes = GameObject.FindGameObjectsWithTag("Clothes");

                foreach (GameObject item in clothes)
                {
                    SkinnedMeshRenderer mr = item.GetComponent<SkinnedMeshRenderer>();
                    mr.material.color = output;
                }*/

      //  SkinnedMeshRenderer mr = clothes.GetComponent<SkinnedMeshRenderer>();
     //   mr.material.color = output;

    }

    public void changeColour(Transform selection)
    {
       // GameObject clothes = GameObject.FindGameObjectWithTag("Clothes");
        SkinnedMeshRenderer mr = selection.GetComponent<SkinnedMeshRenderer>();
        mr.material.color = output;
    }
}
