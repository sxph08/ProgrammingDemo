using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Cube;
    public Transform spawnpoint;
    public float starttime;
    public float currenttime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenttime = starttime;

    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        if (currenttime < 0)
        {
            Instantiate(Cube, spawnpoint.position, quaternion.identity);
            currenttime = starttime;
        }



    }
}
