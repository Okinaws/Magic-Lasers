using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserManager : Singleton<LaserManager>
{
    private List<LaserGun> lasers = new List<LaserGun>();
    private List<GameObject> lines = new List<GameObject>();
    private List<GameObject> hits = new List<GameObject>();
    [SerializeField]
    public float maxStepDistance;
    [SerializeField]
    public GameObject[] linePrefabs;
    [SerializeField]
    public GameObject[] hitPrefabs;
    public GameObject[] flashPrefabs;

    public int raycastMask;

    private void Start()
    {
        raycastMask = 1 << LayerMask.NameToLayer("Raycast Only");
        raycastMask = ~raycastMask; 
    }
}
