using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    ///  This Script should be placed on every Room, it tracks the progress and handles the spawns
    /// </summary>

    [SerializeField] public int enemyCount;
    [SerializeField] public bool roomCleared = false;

    // individual enemy counters
    private int Enemy1Count;
    private int Enemy2Count;
    private int Enemy3Count;

    // enemy GameObjects
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;


    private void Start()
    {
        // Simple: if difficulty == X THEN EnemyCount == X
        // Spawn X amount of enemy1

        // Advanced: new if difficulty == X THEN Enemy1Count = X, Enemy2Count = X, Enemy3Count = X
        // EnemyCount = Enemy1Count + Enemy2Count + Enemy3Count
        // Debug.Log($"{this.name} enemy count: {EnemyCount}")
        // Spawn X amount of enemy1, enemy2, enemy3
    }

    private void RoomCleared()
    {
        if (roomCleared)
        {
            // update RoomsCleared on DifficultyScaler.cs with +1
        }
    }


    private void RandomizeEnemySpawns()
    {
        // create new child gameObject EnemyHolder


    }

    private void RandomizeDecoSpawns()
    {
        // create new child gameObject DecoHolder


    }

    private void ClearRoom()
    {
        // possible method for destroying DecoHolder and EnemyHolder if difficult to disable whole room
    }
}
