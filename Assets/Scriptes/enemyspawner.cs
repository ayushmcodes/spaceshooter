using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] List<waveconfig> waves;
    [SerializeField] int startingwave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int waveindex=startingwave;waveindex<waves.Count;waveindex++)
        {
            var currentwave = waves[waveindex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentwave));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(waveconfig wavecon)
    {
     for(int enemycount=0;enemycount<wavecon.GetNumberOfEnemies();enemycount++)
        {
            Instantiate(
                wavecon.GetEnemyPrefab(),
                wavecon.GetWayPoints()[0].transform.position, 
                Quaternion.identity);
            yield return new WaitForSeconds(wavecon.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
