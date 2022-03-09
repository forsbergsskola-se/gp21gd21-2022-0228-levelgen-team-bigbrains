using UnityEngine;

public class RoomExit : MonoBehaviour
{


    /// <summary>
    /// this script is placed on an empty gameObject at every room exit. It decides if the player can exit or not
    /// </summary>


    private void OnCollisionEnter(Collision collision)
    {
        // Only execute if Player
        if (!collision.gameObject.CompareTag("Player")) return;


        var room = gameObject.GetComponentInParent<Spawner>();

        if (room.enemyCount == 0)
            room.roomCleared = true;

        if (room.roomCleared)
        {
            // Execute RoomCleared method in Room.cs
            // Execute Room & Hallway gen logic - have room and Hallways together as one prefab
            // Execute Room Enemy and Deco spawns logic
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
