using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantied2D : MonoBehaviour
{
    [SerializeField] GameObject quad;
    [SerializeField] float dist = 1;
    [SerializeField] int quadNumberY = 10;
    [SerializeField] int quadNumberX = 5;

    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        for (int i = 0; i < quadNumberX; i++)
        {
            for (int j = 0; j < quadNumberY; j++)
            {
                Instantiate(quad, pos, Quaternion.identity, transform);
                pos.y = pos.y + dist;
            }
            pos.y = transform.position.y;
            pos.x = pos.x + dist;
        }
    }
}
