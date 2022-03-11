using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
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

    public GameObject enemySpawnManager;

    private void Start()
    {
        difficultyScaler = FindObjectOfType<DifficultyScaler>().GetComponent<DifficultyScaler>();

        // get enemyCounts from difficultyScaler
        enemy1Count = difficultyScaler.enemy1Count;
        enemy2Count = difficultyScaler.enemy2Count;
        enemy3Count = difficultyScaler.enemy3Count;


        // spawn enemies
        RandomizeEnemySpawns();
    }

    private void Update()
    {
        // check current enemy count by doing a tag count
        currentTotalEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // update each fogGateText with enemyCount
        var fogGates = gameObject.GetComponentsInChildren(typeof(FogGate));
        foreach (var fogGate in fogGates)
        {
            var doorText = fogGate.GetComponent<FogGate>().tmp;
            doorText.text = currentTotalEnemyCount > 0 ? $"{currentTotalEnemyCount}" : "";
        }

        // room cleared logic
        if (currentTotalEnemyCount !<= 0)
            roomCleared = false;
        if (currentTotalEnemyCount <= 0)
            roomCleared = true;

        readyToBeDestroyed = roomCleared;
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

            // create and add random offsets to x and z values
            var offset = Random.Range(-3f, 3f);
            var offset2 = Random.Range(-3f, 3f);
            var randomOffset = new Vector3(randomChildTransform.x + offset, randomChildTransform.y + 1.7f, randomChildTransform.z + offset2);

            // instantiate the enemy on that position
            Instantiate(enemy, randomOffset, Quaternion.identity);
        }
    }

    public void CheckIfCleared()
    {
        // prints enemy counts, keeping in mind that this method is called by enemies just
        // before they're destroyed, meaning thar currentTotalEnemyCount hasn't been updated with their death

        Debug.Log($"{name} has {(currentTotalEnemyCount - 1)} enemies left.");

        if (currentTotalEnemyCount == 1)
            Debug.Log($"{name} has been cleared of enemies");
    }


    public void DestroyRoom()
    {
        // starts countdown to destroy room if it's cleared
        if (readyToBeDestroyed)
            StartCoroutine(WaitToDestroy());
    }

    private IEnumerator WaitToDestroy()
    {
        Debug.Log($"{name} will be destroyed in 20 seconds - " + Time.time);

        yield return new WaitForSeconds(20f);

        Debug.Log($"{name} was destroyed at " + Time.time);
        Destroy(gameObject);
    }
}
