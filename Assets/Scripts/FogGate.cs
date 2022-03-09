using UnityEngine;

public class FogGate : MonoBehaviour {
    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>

    public BoxCollider boxCollider;
    public ParticleSystemRenderer fogParticleEffect;

    public void DisableFogGate() {
        boxCollider.enabled = false;
        fogParticleEffect.enabled = false;
    }

    private void OnCollisionExit(Collision other) {
        if (!other.gameObject.CompareTag("Player")) return;

        EnableFogGate();
    }

    private void EnableFogGate() {
        boxCollider.enabled = true;
        fogParticleEffect.enabled = true;
    }
}
