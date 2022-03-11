using System;
using TMPro;
using UnityEngine;

public class FogGate : MonoBehaviour {
    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>

    public BoxCollider invisibleWall;
    public ParticleSystemRenderer fogParticleEffect;
    private DifficultyScaler difficultyScaler;
    public GameObject doorText;
    [HideInInspector] public TMP_Text tmp;

    private RoomGenerator roomGenerator;
    public GameObject spawnPoint;
    private Vector3 spawnPos;


    private void Awake()
    {
        tmp = doorText.GetComponent<TMP_Text>();
        roomGenerator = FindObjectOfType<RoomGenerator>().GetComponent<RoomGenerator>();
        spawnPos = spawnPoint.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        var room = gameObject.GetComponentInParent<EnemySpawner>();

        if (room.currentTotalEnemyCount <= 0)
        {
            roomGenerator.GenerateNewRoom(spawnPos);

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
