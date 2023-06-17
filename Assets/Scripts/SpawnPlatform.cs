using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public int platformDistance = 0;

    private void Start()
    {
        foreach (var platform in platforms)
        {
            Instantiate(platform, new Vector3(0,0,platformDistance), transform.rotation);
            platformDistance += 87;
        }
    }

    public GameObject myPlat;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Recycle(myPlat);
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, platformDistance);
        platformDistance += 87;
    }
}
