using UnityEngine;

public class FogGate : MonoBehaviour {
    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>

    public BoxCollider invisibleWall;
    public ParticleSystemRenderer fogParticleEffect;

    public void DisableFogGate()
    {
        invisibleWall.enabled = false;
        fogParticleEffect.enabled = false;
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        EnableFogGate();
    }

    private void EnableFogGate()
    {
        invisibleWall.enabled = true;
        fogParticleEffect.enabled = true;
    }
}
