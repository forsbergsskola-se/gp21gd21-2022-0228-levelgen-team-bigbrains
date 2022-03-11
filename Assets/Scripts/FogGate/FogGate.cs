using UnityEngine;

public class FogGate : MonoBehaviour {
    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>

    public BoxCollider invisibleWall;
    public ParticleSystemRenderer fogParticleEffect;
    private DifficultyScaler difficultyScaler;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        var room = gameObject.GetComponentInParent<Spawner>();

        if (room.currentTotalEnemyCount <= 0) {

            // destroys any previous rooms that are ready to be destroyed
            room.DestroyRoom();


            // use room Gen logic here from RoomExit.cs


            difficultyScaler = FindObjectOfType<DifficultyScaler>().GetComponent<DifficultyScaler>();
            difficultyScaler.ScaleDifficultyUp();
            DisableFogGate();
        }
    }

    public void DisableFogGate()
    {
        invisibleWall.enabled = false;
        //fogParticleEffect.enabled = false;
    }


    public void EnableFogGate()
    {
        invisibleWall.enabled = true;
        //fogParticleEffect.enabled = true;
    }
}
