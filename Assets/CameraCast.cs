using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraCast : MonoBehaviour
{
    private Camera camera;

    private ColorManager colorManager;

    private void Start()
    {
        camera = Camera.main;

        colorManager = FindAnyObjectByType<ColorManager>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 screnPos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(screnPos);

            Physics.Raycast(ray, out RaycastHit hitInfo);
            {
                ColorPicker colorTake = hitInfo.collider.gameObject.GetComponent<ColorPicker>();
                if (colorTake != null) colorManager.ColorPick = colorTake.ColorTake;

                SetColor setColor = hitInfo.collider.gameObject.GetComponent<SetColor>();
                if (setColor != null) setColor.materialQuad.color = colorManager.ColorPick;

                Debug.Log(hitInfo.collider.gameObject.name);
            }
        }
    }
}
