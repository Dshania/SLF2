using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Rendering.CameraUI;

public class ClothesSelect : MonoBehaviour
{
    [SerializeField] private Material highlightedMat;
    public LayerMask raycastLayer;

    private Transform selected;

    //public GameObject colourWheel;

        void Update()
        {

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, raycastLayer))
                {
    
                    var selection = rayHit.collider.transform;
                    // Debug.Log($"{selection}", selection.gameObject);
                    var selectedRenderer = selection.GetComponent<Renderer>();
                    if (selectedRenderer != null)
                    {
                        selectedRenderer.material = highlightedMat;
                    }


            }

        }
    //private Transform highlighted;
    //private Material origMat;
    //public bool isSelected;
    //public Material selectedMat;
    //void Update()
    //{
    //    if (selected != null)
    //    {
    //        highlighted.GetComponent<Renderer>().material = origMat;
    //        highlighted = null;
    //    }
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        RaycastHit rayHit;

    //    if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out rayHit, raycastLayer))
    //    {
    //        highlighted = rayHit.transform;

    //        if (highlighted.CompareTag("Clothes") && highlighted != selected)
    //        {
    //            if (highlighted.GetComponent<Renderer>().material != highlightedMat)
    //            {
    //                origMat = highlightedMat.GetComponent<Renderer>().material;
    //                highlighted.GetComponent<Renderer>().material = highlightedMat;
    //                isSelected = false;
    //            }
    //        }
    //        else
    //        {
    //            highlighted = null;
    //        }
    //    }
         
    //    if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
    //    {
    //        if(selected != null)
    //        {
    //            selected.GetComponent<Renderer>().material = origMat;
    //            selected = null;
    //        }
    //        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out rayHit, raycastLayer))
    //        {
    //            selected = rayHit.collider.transform;
    //            if(selected.CompareTag("Clothes"))
    //            {
    //                selected.GetComponent <Renderer>().material = selectedMat;
    //                isSelected = true;
    //            }
    //            else
    //            {
    //                selected = null;
    //            }
    //        }
    //    }
    //}
}
