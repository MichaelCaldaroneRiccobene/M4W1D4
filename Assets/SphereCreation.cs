using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SphereCreation : MonoBehaviour
{
    [SerializeField] private Transform cubePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Transform parent;
    [SerializeField] private float radius;
    [SerializeField] private int numberCube;

    [SerializeField] private float minRandomScale = 0.2f;
    [SerializeField] private float maxRandomScale = 0.6f;
    [SerializeField] private float velocityExsplosion = 0.1f;
    [SerializeField] private float timeWaite = 0.5f;

    [SerializeField] private bool isInside;
    [SerializeField] private bool isRandomScale;
    [SerializeField] private bool isRandomRotation;
    [SerializeField] private bool isRealTime = false;
    [SerializeField] private bool isAnimate = false;
    [SerializeField] private bool isFollow = false;
    [SerializeField] private bool isRegenerate = false;
    [SerializeField] private bool isExsplosion = false;

    private int getCubeNumber;
    private float getRadius;
    private float getMinRandom;
    private float getMaxRandom;

    private bool getInside;
    private bool getRandomScale;
    private bool getRandomRotation;


    private List<Transform> cubePrefabList = new List<Transform>();
    private float randomScale;

    private void Start()
    {
        GenerationAllSphere();
        Equals();
    }

    private void Update()
    {
        if (isRegenerate) GenerationAllSphere();

        Explosion();
        RealTime();
    }

    private void GenerationAllSphere()
    {
        if (isAnimate) StartCoroutine(TimeCreatingSphere());
        else CreatingSphere();
    }

    private void Explosion()
    {
        if(!isExsplosion) return;

        radius += velocityExsplosion;
        numberCube -= 5;
    }

    private void RealTime()
    {
        if (!isRealTime) return;

        bool parametersChanged =
            transform.position != target.position ||
            getRadius          != radius          ||
            getCubeNumber      != numberCube      ||
            getMinRandom       != minRandomScale  ||
            getMaxRandom       != maxRandomScale  ||
            getInside          != isInside        ||
            getRandomScale     != isRandomScale   ||
            getRandomRotation  != isRandomRotation;

        if(parametersChanged)
        {
            Equals();

            if (isAnimate) StartCoroutine(TimeCreatingSphere());
            else CreatingSphere();
        }
    }

    IEnumerator TimeCreatingSphere()
    {
        isRegenerate = false;

        for (int i = 0; i < numberCube; i++)
        {
            if (!isRealTime) yield break;

            GenerateSpheres(i);
            yield return new WaitForSeconds(timeWaite);
        }

        for (int i = numberCube; i < cubePrefabList.Count; i++)
        {
            if (!isRealTime) yield break;

            cubePrefabList[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(timeWaite);
        }

        Debug.Log("Active Cubes " + numberCube + " Total Cubes " + cubePrefabList.Count);
    }

    private void CreatingSphere()
    {
        isRegenerate = false;
        randomScale = Random.Range(minRandomScale, maxRandomScale);

        for (int i = 0; i < numberCube; i++)
        {
            GenerateSpheres(i);
        }

        for (int i = numberCube; i < cubePrefabList.Count; i++)
        {
            cubePrefabList[i].gameObject.SetActive(false);
        }

        Debug.Log("Active Cubes " + numberCube + " Total Cubes " + cubePrefabList.Count);
    }

    private void GenerateSpheres(int i)
    {
        randomScale = Random.Range(minRandomScale, maxRandomScale);
        Transform cube = GenerateCubes(i);

        if (isFollow)
        {
            Vector3 mode = isInside ? Random.insideUnitSphere : Random.onUnitSphere;
            cube.position = target.position + mode * radius;
        }
        else
        {
            Vector3 mode = isInside ? Random.insideUnitSphere : Random.onUnitSphere;
            cube.position = mode * radius;
        }
        RandomValue(cube);
    }

    private Transform GenerateCubes(int i)
    {
        Transform cube;
        if (i < cubePrefabList.Count)
        {
            cube = cubePrefabList[i];
            cube.gameObject.SetActive(true);
        }
        else
        {
            cube = Instantiate(cubePrefab);
            cube.SetParent(parent);
            cubePrefabList.Add(cube);
        }

        return cube;
    }

    private void RandomValue(Transform cube)
    {
        if (isRandomRotation) cube.rotation = Random.rotation;
        if (isRandomScale) cube.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    private void Equals()
    {
        transform.position = target.position;

        getRadius = radius;
        getCubeNumber = numberCube;
        getMinRandom = minRandomScale;
        getMaxRandom = maxRandomScale;

        getInside = isInside;
        getRandomScale = isRandomScale;
        getRandomRotation = isRandomRotation;
    }
}
