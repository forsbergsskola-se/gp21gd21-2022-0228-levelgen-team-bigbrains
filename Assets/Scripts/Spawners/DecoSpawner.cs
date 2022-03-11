using UnityEngine;
using Random = UnityEngine.Random;

public class DecoSpawner : MonoBehaviour {
    void Awake() {
        var random = Random.Range(0, 10);

        if (random < 8) {
            Destroy(gameObject);
            Debug.Log($"{this.name} destroyed");
        }
    }
}
