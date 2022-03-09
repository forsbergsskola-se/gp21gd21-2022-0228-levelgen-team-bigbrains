using UnityEngine;

public class FogGate : MonoBehaviour
{

    /// <summary>
    /// Toggles invisible walls on and off, probably placed on Hallways that connect rooms and block/ allow passage
    /// </summary>


    // each hallway will have two colliders and two fog particle effects

    // fed a box collider and a particle effect to know which ones to toggle
    private void DisableInvisibleWall(BoxCollider boxCollider, ParticleSystemRenderer fogParticleEffect)
    {
        boxCollider.enabled = false;
        fogParticleEffect.enabled = false;
    }

    private void EnableInvisibleWall(BoxCollider boxCollider, ParticleSystemRenderer fogParticleEffect)
    {
        boxCollider.enabled = true;
        fogParticleEffect.enabled = true;
    }
}
