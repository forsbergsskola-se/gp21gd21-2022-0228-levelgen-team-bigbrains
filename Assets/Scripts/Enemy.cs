using Unity.Multiplayer.Samples.BossRoom;
using UnityEngine;

public class Enemy : MonoBehaviour {
    /// <summary>
    /// this script goes on each Enemy and monitors enemy logic
    /// </summary>

    private Spawner spawner;

    private void Awake() {
        GetComponent<NetworkLifeState>().LifeState.OnValueChanged += OnValueChanged;
    }

    private void OnValueChanged(LifeState previousvalue, LifeState newvalue) {
        if (newvalue == LifeState.Dead) {
            OnDeath();
        }
    }

    private void OnDeath() {
        Debug.Log($"{this} died");

        spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
        spawner.currentTotalEnemyCount--;
    }

}
