using UnityEngine;

public class Exit : MonoBehaviour
{
    private EnemySpawner EnemySpawner;

    private void Awake()
    {
        EnemySpawner = gameObject.GetComponentInParent<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        EnemySpawner.DestroyRoom();

    }
}
