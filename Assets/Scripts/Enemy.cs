using UnityEngine;

public class Enemy : MonoBehaviour {
    /// <summary>
    /// this script goes on each Enemy and monitors enemy logic
    /// </summary>

    private Spawner spawner;
    private Transform target;
    public int aggroRange;
    public int moveSpeed;

    // [SerializeField] private float maxHealth;
    // [SerializeField] private float currentHealth;

    // public float attackRate = 2.5f;
    // public float attackRange = 1.5f;
    // private float nextAttackTime;

    // private float CurrentHealth {
    //     get => currentHealth;
    //     set {
    //         currentHealth = value;
    //         if (currentHealth <= 0) {
    //             OnDeath();
    //         }
    //     }
    // }

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // CurrentHealth = maxHealth;
    }

    private void FixedUpdate() {
        Chase();
        // Attack();
    }

    // private void Attack() {
    //     if (Vector3.Distance(transform.position, target.position) < attackRange) {
    //         if (Time.time >= nextAttackTime) {
    //             player.TakeDamage(1);
    //             nextAttackTime = Time.time + 1f / attackRate;
    //         }
    //     }
    // }

    private void Chase() {
        if (Vector3.Distance(transform.position, target.position) < aggroRange) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDeath() {
        spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
        spawner.currentTotalEnemyCount--;

        Destroy(gameObject);
    }

}
