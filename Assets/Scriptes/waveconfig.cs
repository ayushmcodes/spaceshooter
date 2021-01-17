using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Configuration")]
public class waveconfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timebetweenspawns = 0.5f;
    [SerializeField] float spawnrandomfactor = 0.3f;
    [SerializeField] int numberofemenies = 5;
    [SerializeField] float movespeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public List<Transform> GetWayPoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timebetweenspawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnrandomfactor;
    }
    public int GetNumberOfEnemies()
    {
        return numberofemenies;
    }
    public float GetMoveSpeed()
    {
        return movespeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
