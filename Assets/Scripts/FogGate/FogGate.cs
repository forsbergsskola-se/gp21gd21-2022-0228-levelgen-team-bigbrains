using UnityEngine;

public class FogGate : MonoBehaviour {
    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>

    public BoxCollider invisibleWall;
    public ParticleSystemRenderer fogParticleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Disable FogGate");

        DisableFogGate();
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
