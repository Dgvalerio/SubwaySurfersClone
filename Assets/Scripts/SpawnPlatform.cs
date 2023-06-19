using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();
    public int platformDistance = 0;

    private Transform _player;
    private Transform _currentPlatformPoint;
    private int _currentPlatformIndex;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
        foreach (var platform in platforms)
        {
            var updatedPlatform = Instantiate(platform, new Vector3(0,0,platformDistance), transform.rotation).transform;
            currentPlatforms.Add(updatedPlatform);
            platformDistance += 87;
        }

        _currentPlatformPoint = currentPlatforms[_currentPlatformIndex].GetComponent<Platform>().endPoint;
    }

    private void Update()
    {
        var distance = _player.position.z - _currentPlatformPoint.position.z;

        if (!(distance >= 5)) return;

        Recycle(currentPlatforms[_currentPlatformIndex].gameObject);
        _currentPlatformIndex++;

        if (_currentPlatformIndex > currentPlatforms.Count - 1)
        {
            _currentPlatformIndex = 0;
        }

        _currentPlatformPoint = currentPlatforms[_currentPlatformIndex].GetComponent<Platform>().endPoint;
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, platformDistance);
        platformDistance += 87;
    }
}
