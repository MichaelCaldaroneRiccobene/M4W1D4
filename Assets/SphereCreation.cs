using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SphereCreation : MonoBehaviour
{
    [SerializeField] private Transform cubePrefab;
    [SerializeField] private float radius;
    [SerializeField] private int cubeNumber;

    [SerializeField] private float minRandom = 0.2f;
    [SerializeField] private float maxRandom = 0.6f;

    [SerializeField] private bool inside;
    [SerializeField] private bool israndomScale;
    [SerializeField] private bool israndomRotation;
    [SerializeField] private bool isRegenerate = false;

    private List<Transform> cubePrefabs = new List<Transform>();
    private float randomScale;

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        if (isRegenerate) Regenerate();
    }

    private void Regenerate()
    {
        isRegenerate = false;
        for (int i = 0; i < cubePrefabs.Count; i++) Destroy(cubePrefabs[i].gameObject);

        cubePrefabs.Clear();
        Generate();
    }

    private void Generate()
    {
        if (inside) CreateSphereInside();
        else CreateSphereOut();

        Debug.Log(cubePrefabs.Count);
    }
    private void CreateSphereInside()
    {
        for (int i = 0; i < cubeNumber; i++)
        {
            randomScale = (Random.Range(minRandom, maxRandom));

            Transform cube = Instantiate(cubePrefab, transform);
            cube.position = Random.insideUnitSphere * radius;
            cubePrefabs.Add(cube);

            RandomValue(cube);
        }
    }

    private void CreateSphereOut()
    {
        for (int i = 0; i < cubeNumber; i++)
        {
            randomScale = (Random.Range(minRandom, maxRandom));

            Transform cube = Instantiate(cubePrefab, transform);
            cube.position = Random.onUnitSphere * radius;
            cubePrefabs.Add(cube);

            RandomValue(cube);
        }
    }

    private void RandomValue(Transform cube)
    {
        if (israndomRotation) cube.rotation = Random.rotation;
        if (israndomScale) cube.localScale = new Vector3(randomScale, randomScale, randomScale);
    }
}
