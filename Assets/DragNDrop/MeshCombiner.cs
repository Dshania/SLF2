using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using Unity.VisualScripting;

public class MeshCombiner
{
    public readonly Dictionary<int, Transform> _RootBoneDictionary = new Dictionary<int, Transform>();
    private readonly Transform[] _boneTransforms = new Transform[67];
    private readonly Transform _transform;
    public Outline outline;
    //private const string ClothesString = "clothes";
    static string tagClothes = "Clothes";

    public MeshCombiner(GameObject rootObj)
    {
        _transform = rootObj.transform;
        TraverseHierarchy(_transform);

      //  rootObj.tag = tagClothes;
    }

    public Transform AddLimb(GameObject boneObj, List<string> boneNames)
    {
        var limb = ProcessBonedObject(boneObj.GetComponentInChildren<SkinnedMeshRenderer>(), boneNames);
        limb.SetParent(_transform);

        limb.localPosition = boneObj.transform.localPosition;
        limb.localRotation = boneObj.transform.localRotation;
        limb.localScale = boneObj.transform.localScale;

        limb.tag = tagClothes;
        
        return limb;
    }

    private Transform ProcessBonedObject(SkinnedMeshRenderer renderer, List<string> boneNames)
    {
        var bonedObject = new GameObject().transform;

        var meshRenderer = bonedObject.gameObject.AddComponent<SkinnedMeshRenderer>();

        //var bones = renderer.bones;
        for (var i = 0; i < boneNames.Count; i++)
        {
            _boneTransforms[i] = _RootBoneDictionary[boneNames[i].GetHashCode()];
           // _boneTransforms[i] = _RootBoneDictionary[bones[i].name.GetHashCode()];
        }

        //SphereCollider collider = bonedObject.AddComponent<SphereCollider>();
        //collider.radius = 2;

        BoxCollider collider = bonedObject.AddComponent<BoxCollider>();
        collider.center = renderer.bounds.center;
        collider.size = renderer.bounds.size;

       // bonedObject.AddComponent<Outline>();

        outline = bonedObject.AddComponent<Outline>();
        outline.enabled = false;

        meshRenderer.bones = _boneTransforms;
        meshRenderer.sharedMesh = renderer.sharedMesh;
        meshRenderer.materials = renderer.sharedMaterials;

        return bonedObject;
    }

    private void TraverseHierarchy(Transform root)
    {
        foreach (Transform child in root)
        {
            // if (child.CompareTag(ClothesString))
            _RootBoneDictionary.Add(child.name.GetHashCode(), child);
            TraverseHierarchy(child);
            
        }
    }
}
