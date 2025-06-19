using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    private ColorManager colorManager;
    private MeshRenderer meshRenderer;
    private Material material;

    private void Start()
    {
        colorManager = FindAnyObjectByType<ColorManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }
    private void OnMouseDown()
    {
        material.color = colorManager.ColorPick;
    }
}
