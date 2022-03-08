using UnityEngine;

public class Hallway : MonoBehaviour
{
    /// <summary>
    /// this script handles the connecting hallways, it triggers difficulty scaling up and gets rooms ready/ or makes them idle
    /// </summary>


    private void OnCollisionEnter(Collision collision)
    {
        // Only execute if Player
        if (!collision.gameObject.CompareTag("Player")) return;

        // Activate script for next Room, unless this is automized
        // Increase progress for difficulty scaling
    }

    private void OnCollisionExit(Collision other)
    {
        // Only execute if Player
        if (!other.gameObject.CompareTag("Player")) return;

        // possibly deactivate last room to save space
    }
}
