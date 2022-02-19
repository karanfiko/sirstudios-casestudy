using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    public float followSpeed;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * followSpeed);
    }
}
