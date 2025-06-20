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
    [SerializeField] private float spawnDelay = 1.5f;
    [SerializeField] private bool isFast = true;

    private Vector3 startLocation;

    private void Start()
    {
        startLocation = transform.position;

        if (isFast ) CreateCubeFast();
        else StartCoroutine(CreateCubeGradually());
    }

    private void CreateCubeFast()
    {
        for (int ii = 0; ii < cubeLargeY; ii++)
        {
            for (int i = 0; i < cubeLargeX; i++)
            {
                for (int j = 0; j < cubeLargeZ; j++)
                {
                    GameObject cube = Instantiate(cubePrefab, startLocation, Quaternion.identity, transform);
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

    private IEnumerator CreateCubeGradually()
    {
        Vector3 spawnPosition = startLocation;

        for (int y = 0; y < cubeLargeY; y++)
        {
            for (int x = 0; x < cubeLargeX; x++)
            {
                for (int z = 0; z < cubeLargeZ; z++)
                {
                    Instantiate(cubePrefab, spawnPosition, Quaternion.identity, transform);
                    spawnPosition.z += distance;

                    yield return new WaitForSeconds(spawnDelay);
                }
                spawnPosition.z = startLocation.z;
                spawnPosition.x += distance;
            }
            spawnPosition.z = startLocation.z;
            spawnPosition.x = startLocation.x;
            spawnPosition.y += distance;
        }
    }
}
