using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    ///  This Script should be placed on every Room, it tracks the progress and handles the spawns
    /// </summary>


    [SerializeField] public int currentTotalEnemyCount;
    [SerializeField] public bool roomCleared = false;

    // individual enemy counters
    private int enemy1Count;
    private int enemy2Count;
    private int enemy3Count;

    // enemy GameObjects
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;


    private void Start()
    {
        // Gets all the below information from DifficultyScaler.cs

        // Advanced: new if roomsCleared == X THEN enemy1Count = X, enemy2Count = X, enemy3Count = X
        // EnemyCount = enemy1Count + enemy2Count + enemy3Count
        // Debug.Log($"{this.name} enemy count: {enemyCount}")
        // Spawn X amount of enemy1, enemy2, enemy3

        // Then we randomize where each enemy spawns here
    }



    public void RandomizeEnemySpawns()
    {
        // create new child gameObject EnemyHolder
        // find all the SpawnPoints by looking for objects with SpawnPoint tag in Child
        // have an array or similar of enemySpawnPoints gameObjects (these are empty)

        // randomRange for spawns points
        // these spawnPoints feed a transform location for the enemies to spawn onto
        // probably best to have an offset, xTransform.Position randomRange(0, 10) to not have overlaps
        // randomize where each enemy is spawned - so not everyone goes to this or that enemySpawnPoint


    }

    public void RandomizeDecoSpawns()
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
