using UnityEngine;

public class TeleportableObject : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player") && other.TryGetComponent<FirstPersonController>(out var player))
        //{
            //PlayerStats.instance.Teleport(destination.position, destination.rotation);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(destination.position, 0.4f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }
}
//https://www.youtube.com/watch?v=I7M8T3qU-_E