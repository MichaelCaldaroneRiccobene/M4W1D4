using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int cubeLargeX = 10;
    [SerializeField] private int cubeLargeY = 10;
    [SerializeField] private int cubeLargeZ = 10;
    [SerializeField] private float distance = 1.5f;


    private void Start()
    {
        Vector3 startLocation = transform.position;

        for (int ii = 0; ii < cubeLargeY; ii++)
        {
            for (int i = 0; i < cubeLargeX; i++)
            {
                for (int j = 0; j < cubeLargeZ; j++)
                {
                    GameObject cube = Instantiate(cubePrefab, startLocation, Quaternion.identity,transform);
                    startLocation.z = startLocation.z + distance;
                }
                startLocation.z = transform.position.z;
                startLocation.x = startLocation.x + distance;
            }
            startLocation.z = transform.position.z;
            startLocation.x = transform.position.x;
            startLocation.y = startLocation.y + distance;
        }
    }
}
