using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _horizontalTurnSensitivity = 7f;
    [SerializeField, Min(0f)] private float _verticalTurnSensitivity = 10f;
    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 89f;

    private Transform _cameraTransform;
    private Transform _transform;
    private float _cameraAngle;

    private void Awake()
    {
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        _transform = transform;
        _cameraAngle = _cameraTransform.localEulerAngles.x;
    }

    public void Rotate(Vector2 direction)
    {
        _cameraAngle -= direction.y * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
        _transform.Rotate(Vector3.up * _horizontalTurnSensitivity * direction.x);
    }
}