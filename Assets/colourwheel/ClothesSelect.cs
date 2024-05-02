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
    private Transform selected;
    public LayerMask raycastLayer;
    public ClothesColour cl;
    public GameObject colourWheel;
    [SerializeField] Color pickedColour;

    private void Update()
    {
        pickedColour = cl.output;
    }
    public void onSelected()
    {
        if (selected != null)
        {
            selected.gameObject.GetComponent<Outline>().enabled = false;
            selected = null;
        }
        colourWheel.SetActive(true);

        RaycastHit rayHit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rayHit, raycastLayer))
        {
            var selection = rayHit.collider.transform;
            var selectedRenderer = selection.GetComponent<Outline>();

            if (selection.CompareTag("Clothes"))
            {
                // Debug.Log($"{selection}", selection.gameObject);
                if (selectedRenderer != null)
                {
                    selectedRenderer.enabled = true;
                    if (selectedRenderer.enabled)
                    {
                        SkinnedMeshRenderer mr = selection.gameObject.GetComponent<SkinnedMeshRenderer>();
                        mr.material.color = pickedColour;
                    }
                }
                else
                {
                    selectedRenderer.enabled = false;
                    selectedRenderer = null;
                }

                selected = selection;
            }
            else if (selection.CompareTag("Untagged"))
            {
                selectedRenderer.enabled = false;
                selection = null;
            }
        }
    }
}
