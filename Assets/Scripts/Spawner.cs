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
    public bool readyToBeDestroyed = false;

    // individual enemy counters
    private int enemy1Count;
    private int enemy2Count;
    private int enemy3Count;

    // enemy GameObjects
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // individual decoration counters;
    private int decoration1Count;
    private int decoration2Count;
    private int decoration3Count;

    // decoration GameObjects

    public GameObject decoration1;
    public GameObject decoration2;
    public GameObject decoration3;

    // spawning
    private GameObject enemySpawnManager;
    private GameObject decorationSpawnManager;

    private void Start()
    {
        difficultyScaler = FindObjectOfType<DifficultyScaler>().GetComponent<DifficultyScaler>();

        // get enemyCounts from difficultyScaler
        enemy1Count = difficultyScaler.enemy1Count;
        enemy2Count = difficultyScaler.enemy2Count;
        enemy3Count = difficultyScaler.enemy3Count;

        // add together enemies to get total
        currentTotalEnemyCount = enemy1Count + enemy2Count + enemy3Count;
        Debug.Log($"{name} enemy count: {currentTotalEnemyCount}");

        // get spawnManagers
        enemySpawnManager = GameObject.Find("EnemySpawnManager");
        decorationSpawnManager = GameObject.Find("DecorationSpawnManager");

        // spawn enemies and decorations
        RandomizeEnemySpawns();
        RandomizeDecoSpawns();
    }

    private void Update()
    {
        if (currentTotalEnemyCount !>= 0) return;

        if (!roomCleared)
            roomCleared = true;

        if (roomCleared)
            readyToBeDestroyed = true;
    }

    public void RandomizeEnemySpawns()
    {
       // can spawn any enemy based on their total count
       SpawnEnemyType(enemy1Count, enemy1);
       SpawnEnemyType(enemy2Count, enemy2);
       SpawnEnemyType(enemy3Count, enemy3);
    }

    private void SpawnEnemyType(int enemyCount, GameObject enemyObject)
    {
        // loop until it's reached enemyCount amount
        for (var i = 0; i <= enemyCount; i++)
        {
            var enemy = enemyObject;

            // get a random child number, then a random child (a SpawnPoint), and its transform
            var randomInt = Random.Range(0, enemySpawnManager.transform.childCount -1);
            var randomChild =  enemySpawnManager.transform.GetChild(randomInt).gameObject;
            var randomChildTransform = randomChild.transform.position;

            // can have an offset:
            // var offset = Random.Range(0, 5f);
            // add or minus from transform of randomChildTransform

            // instantiate the enemy on that position
            Instantiate(enemy, randomChildTransform, Quaternion.identity);
        }
    }

    public void RandomizeDecoSpawns()
    {
        decoration1Count = Random.Range(1, 5);
        decoration2Count = Random.Range(1, 3);
        decoration3Count = Random.Range(1, 2);

        // can spawn any decoration based on their total count
        SpawnDecorationType(decoration1Count, decoration1);
        SpawnDecorationType(decoration2Count, decoration2);
        SpawnDecorationType(decoration3Count, decoration3);
    }

    private void SpawnDecorationType(int decorationCount, GameObject decorationObject)
    {
        // loop until it's reached decorationCount amount
        for (var i = 0; i <= decorationCount; i++)
        {
            var decoration = decorationObject;

            // get a random child number, then a random child (a SpawnPoint), and its transform
            var randomInt = Random.Range(0, decorationSpawnManager.transform.childCount -1);
            var randomChild =  decorationSpawnManager.transform.GetChild(randomInt).gameObject;
            var randomChildTransform = randomChild.transform.position;

            // can have an offset:
            // var offset = Random.Range(0, 5f);
            // add or minus from transform of randomChildTransform

            // instantiate the decoration on that position
            Instantiate(decoration, randomChildTransform, Quaternion.identity);
        }
    }

    public void DestroyRoom()
    {
        if (readyToBeDestroyed)
            Destroy(gameObject);
    }
}
