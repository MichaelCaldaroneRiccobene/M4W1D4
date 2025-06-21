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
    [SerializeField] private float velocity = 0.1f;

    [SerializeField] private bool isInside;
    [SerializeField] private bool isRandomScale;
    [SerializeField] private bool isRandomRotation;
    [SerializeField] private bool isRealTime = false;
    [SerializeField] private bool isRegenerate = false;
    [SerializeField] private bool isExsplosion = false;

    private float getRadius;
    private int getCubeNumber;
    private float getMinRandom;
    private float getMaxRandom;

    private bool getInside;
    private bool getRandomScale;
    private bool getRandomRotation;


    private List<Transform> cubePrefabs = new List<Transform>();
    private float randomScale;

    private void Start()
    {
        Generate();

        Equals();
    }

    private void Update()
    {
        if (isRegenerate) Regenerate();

        RealTime();

        Explosion();
    }

    private void Explosion()
    {
        if(!isExsplosion) return;

        radius += velocity;
        cubeNumber -= 5;
    }

    private void RealTime()
    {
        if (!isRealTime) return;

        if(getRadius != radius || getCubeNumber != cubeNumber || getMinRandom != minRandom || getMaxRandom != maxRandom || getInside != isInside || getRandomScale != isRandomScale || getRandomRotation != isRandomRotation)
        {
            Equals();

            Regenerate();
        }
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
        if (isInside) CreateSphereInside();
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
        if (isRandomRotation) cube.rotation = Random.rotation;
        if (isRandomScale) cube.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    private void Equals()
    {
        getRadius = radius;
        getCubeNumber = cubeNumber;
        getMinRandom = minRandom;
        getMaxRandom = maxRandom;

        getInside = isInside;
        getRandomScale = isRandomScale;
        getRandomRotation = isRandomRotation;
    }
}
