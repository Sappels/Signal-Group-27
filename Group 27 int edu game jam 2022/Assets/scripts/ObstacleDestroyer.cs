
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("FuelTank"))
        {
            Destroy(other.gameObject);
        }
    }
}
