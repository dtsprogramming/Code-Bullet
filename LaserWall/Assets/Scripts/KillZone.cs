using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Conveyor")
        {
            Destroy(other.gameObject);
        }
    }
}
