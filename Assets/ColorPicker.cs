using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public Color ColorTake;

    private ColorManager colorManager;
    private MeshRenderer meshRenderer;
    private Material material;

    private void Start()
    {
        colorManager = FindAnyObjectByType<ColorManager>();

        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        material.color = ColorTake;
    }
    //private void OnMouseDown()
    //{
    //    colorManager.ColorPick = ColorTake;
    //}
}
