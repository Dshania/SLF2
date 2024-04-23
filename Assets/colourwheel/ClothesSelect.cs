using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Rendering.CameraUI;
using static UnityEditor.Rendering.InspectorCurveEditor;

public class ClothesSelect : MonoBehaviour
{
    //  private Transform highlight;

    // public ClothesColour cl;

    /* void Update()
     {
         if (highlight != null)
         {
             var selctionRend = highlight.GetComponent<Renderer>();
             selctionRend.material.color = defaultMat;
             highlight = null;
         }

         RaycastHit rayHit;
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out rayHit, raycastLayer))
         {
             var selection = rayHit.collider.transform;

             if (selection.CompareTag("Clothes"))
             {
                 // Debug.Log($"{selection}", selection.gameObject);
                 var selectedRenderer = selection.GetComponent<Renderer>();
                 if (selectedRenderer != null)
                 {
                     selectedRenderer.material.color = highlightedMat;
                 }
                 else
                 {
                     selectedRenderer = null;
                 }

                 highlight = selection;
             }
         }

         if (Input.GetKey(KeyCode.Mouse0) &&  Physics.Raycast(ray, out rayHit, raycastLayer))
         {
             if (selected != null)
             {
                 selected.GetComponent<Renderer>().material.color = selectedMat;
                 selected = null;
             }

             if (EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out rayHit, raycastLayer))
             {
                 selected = rayHit.collider.transform;
                 if (selected.CompareTag("Clothes"))
                 {
                     selected.GetComponent<Renderer>().material.color = selectedMat;

                 }
             }

             cl.changeColour();
         }
     }*/

    private RaycastHit rayHit;
    private Transform selected;
    public LayerMask raycastLayer;

    private void Update()
    {

    }

    public void onSelected()
    {
        /* selected = rayHit.transform;
         Debug.Log(selected.name);

         if (selected != null)
         {
             selected.gameObject.GetComponent<Outline>().enabled = false;
         }
         if (selected)
                 {
                     selected.gameObject.GetComponent<Outline>().enabled = false;
                     selected = null;
                 }*/

        if (selected != null)
        {
            selected.gameObject.GetComponent<Outline>().enabled = false;
        }

        RaycastHit rayHit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rayHit, raycastLayer))
        {
            var selection = rayHit.collider.transform;

            if (selection.CompareTag("Clothes"))
            {
                // Debug.Log($"{selection}", selection.gameObject);
                var selectedRenderer = selection.GetComponent<Outline>();
                if (selectedRenderer != null)
                {
                    selected.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    selectedRenderer = null;
                }

                selected = selection;
            }
        }
    }
}
