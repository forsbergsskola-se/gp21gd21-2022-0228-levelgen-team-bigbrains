using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    /// <summary>
    ///  This Script should be placed on every Room, it tracks the progress and handles the spawns
    /// </summary>


    private DifficultyScaler difficultyScaler;
    public int currentTotalEnemyCount;
    public bool roomCleared = false;

    // individual enemy counters
    private int enemy1Count;
    private int enemy2Count;
    private int enemy3Count;

    // enemy GameObjects
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    private GameObject enemySpawnManager;


    private void Start()
    {
        difficultyScaler = FindObjectOfType<DifficultyScaler>();

        // get enemyCounts from difficultyScaler
        enemy1Count = difficultyScaler.enemy1Count;
        enemy2Count = difficultyScaler.enemy2Count;
        enemy3Count = difficultyScaler.enemy3Count;

        // add together enemies to get total
        currentTotalEnemyCount = enemy1Count + enemy2Count + enemy3Count;
        Debug.Log($"{name} enemy count: {currentTotalEnemyCount}");

        enemySpawnManager = GameObject.Find("EnemySpawnManager");
    }

    
    public void RandomizeEnemySpawns()
    {
       SpawnEnemy(enemy1Count, enemy1);
       SpawnEnemy(enemy2Count, enemy2);
       SpawnEnemy(enemy3Count, enemy3);
    }

    private void SpawnEnemy(int enemyCount, GameObject enemy)
    {
        for (var i = 0; i <= enemyCount; i++)
        {
            var easyEnemy = enemy;

            // get a random child number, then a random child, and its transform
            var randomInt = UnityEngine.Random.Range(0, enemySpawnManager.transform.childCount -1);
            var randomChild =  enemySpawnManager.transform.GetChild(randomInt).gameObject;
            var randomChildTransform = randomChild.transform.position;

            // can have an offset:
            // var offset = Random.Range(0, 5f);
            // add or minus from transform of randomChildTransform

            // instantiate the enemy on that position
            Instantiate(easyEnemy,randomChildTransform,Quaternion.identity);
        }

    }
    public void RandomizeDecoSpawns()
    {
        // create new child gameObject DecoHolder
        // create logic here for how many decorations to spawn

        // will use an array too or similar
        // same shit as up aboce
    }

    public void DestroyRoom()
    {
        // possible method for destroying DecoHolder and EnemyHolder if difficult to disable whole room
    }
}
