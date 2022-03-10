using UnityEngine;

public class Enemy : MonoBehaviour {
    /// <summary>
    /// this script goes on each Enemy and monitors death logic
    /// </summary>

    private Spawner spawner;

    private void OnDeath() {
        spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
        spawner.currentTotalEnemyCount--;

        Destroy(gameObject);
    }

}
