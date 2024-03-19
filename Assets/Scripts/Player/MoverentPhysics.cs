using UnityEngine;

public class MoverentPhysics : MonoBehaviour
{
    private Transform _cameraTransform;

    public Vector3 Forward { get; private set; }
    public Vector3 Right { get; private set; }

    private void Awake()
    {
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void FixedUpdate()
    {
        Forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
    }
}