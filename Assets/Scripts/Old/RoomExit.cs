using UnityEngine;

public class RoomExit : MonoBehaviour {
    /// <summary>
    /// this script is placed on an empty gameObject at every room exit. It decides if the player can exit or not
    /// </summary>

    private DifficultyScaler difficultyScaler;
    private RoomGenerator roomGenerator;
    private FogGate fogGate;

    public void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Player")) return;

        var room = gameObject.GetComponentInParent<EnemySpawner>();

        if (room.currentTotalEnemyCount == 0) {
            //supposed to destroy the previous room, not current
            room.DestroyRoom();
            //create next room
            roomGenerator = FindObjectOfType<RoomGenerator>().GetComponent<RoomGenerator>();
            roomGenerator.GenerateNewRoom();
            //fill up the next room
            room.RandomizeEnemySpawns();

            difficultyScaler = FindObjectOfType<DifficultyScaler>().GetComponent<DifficultyScaler>();
            difficultyScaler.ScaleDifficultyUp();

            fogGate = gameObject.GetComponentInChildren<FogGate>();
            fogGate.DisableFogGate();
        }
    }
}
