using UnityEngine;

public class ObjectShadow : MonoBehaviour
{
    public Transform target;
    public Transform lightSource;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(target.position, target.position - lightSource.position, out hit))
        {
            if (hit.collider.CompareTag("WallCollider"))
            {
                transform.position = hit.point;
            }
        }
    }
}