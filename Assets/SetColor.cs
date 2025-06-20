using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    private ColorManager colorManager;
    private MeshRenderer meshRenderer;
    public Material materialQuad;

    private void Start()
    {
        colorManager = FindAnyObjectByType<ColorManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        materialQuad = meshRenderer.material;
    }
    //private void OnMouseDown()
    //{
    //    materialQuad.color = colorManager.ColorPick;
    //}
}
