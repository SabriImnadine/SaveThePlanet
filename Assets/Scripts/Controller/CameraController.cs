using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z // généralement -10 pour les caméras 2D
            );
        }
    }
}

