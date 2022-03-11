using System;
using Unity.Multiplayer.Samples.BossRoom;
using UnityEngine;

public class Enemy : MonoBehaviour {
    /// <summary>
    /// this script goes on each Enemy and monitors enemy logic
    /// </summary>

    private EnemySpawner spawner;

    // private void Awake() {
    //     GetComponent<NetworkLifeState>().LifeState.OnValueChanged += OnValueChanged;
    // }
    //
    // private void OnValueChanged(LifeState previousvalue, LifeState newvalue) {
    //     if (newvalue == LifeState.Dead) {
    //         OnDeath();
    //     }
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnDeath();
            Destroy(gameObject);
        }
    }

    private void OnDeath() {

        spawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        spawner.CheckIfCleared();

        //spawner.currentTotalEnemyCount--;
    }

}
