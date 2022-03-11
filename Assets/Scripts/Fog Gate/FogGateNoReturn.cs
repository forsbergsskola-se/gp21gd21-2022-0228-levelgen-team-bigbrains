using UnityEngine;

public class FogGateNoReturn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        GetComponentInParent<FogGate>().EnableFogGate();
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
