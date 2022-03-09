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



    private void RandomizeEnemySpawns()
    {
        // maybe use a forEach to get each spawner
        enemySpawnManager.GetComponentsInChildren<GameObject>();

        for (var i = 0; i <= enemy1Count; i++)
        {
            var easyEnemy = enemy1;

            // get a random child number, then a random child, and its transform
            var randomInt = UnityEngine.Random.Range(0, enemySpawnManager.transform.childCount -1);
            var randomChild =  enemySpawnManager.transform.GetChild(randomInt).gameObject;
            var randomChildTransform = randomChild.transform.position;

            // instantiate the enemy on that position
            Instantiate(easyEnemy,randomChildTransform,Quaternion.identity);
        }

        for (var i = 0; i <= enemy2Count; i++)
        {

        }

        for (var i = 0; i <= enemy3Count; i++)
        {

        }
        // create new child gameObject EnemyHolder
        // find all the SpawnPoints by looking for objects with SpawnPoint tag in Child
        // have an array or similar of enemySpawnPoints gameObjects (these are empty)

        // randomRange for spawns points
        // these spawnPoints feed a transform location for the enemies to spawn onto
        // probably best to have an offset, xTransform.Position randomRange(0, 10) to not have overlaps
        // randomize where each enemy is spawned - so not everyone goes to this or that enemySpawnPoint
    }


    private void RandomizeDecoSpawns()
    {
        // create new child gameObject DecoHolder
        // create logic here for how many decorations to spawn

        // will use an array too or similar
        // same shit as up aboce


    }

    public void ClearRoom()
    {
        // possible method for destroying DecoHolder and EnemyHolder if difficult to disable whole room
    }
}
