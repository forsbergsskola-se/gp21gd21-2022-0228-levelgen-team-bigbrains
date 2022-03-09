using UnityEngine;

public class RoomExit : MonoBehaviour {
    /// <summary>
    /// this script is placed on an empty gameObject at every room exit. It decides if the player can exit or not
    /// </summary>

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Player")) return;

        var room = gameObject.GetComponentInParent<Spawner>();
        // if (room.enemyCount == 0)
        //     room.roomCleared = true;

        if (room.currentTotalEnemyCount == 0) {
            //supposed to destroy the previous room, not current
            room.DestroyRoom();
            //create next room
            var roomGenerator = gameObject.GetComponent<RoomGenerator>();
            roomGenerator.GenerateNewRoom();
            //fill up the next room
            room.RandomizeDecoSpawns();
            room.RandomizeEnemySpawns();

            // Execute FogGate disabled logic for roomExit

            // tell DifficultyScaler =+1 roomsClearedTotal
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // Only execute if Player
        if (!other.gameObject.CompareTag("Player")) return;

        // Execute FogGate re-enabled logic for roomExit
    }
}
