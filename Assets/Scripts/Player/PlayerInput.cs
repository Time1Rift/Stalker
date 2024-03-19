using UnityEngine;

[RequireComponent(typeof(PlayerMoverent), typeof(PlayerRotation))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private PlayerMoverent _moverent;
    private PlayerRotation _rotation;
    private Vector3 _directionMover;
    private Vector2 _directionRotation;

    private void Awake()
    {
        _moverent = GetComponent<PlayerMoverent>();
        _rotation = GetComponent<PlayerRotation>();
    }

    private void Update()
    {
        _directionMover.x = Input.GetAxis(Horizontal);        
        _directionMover.z = Input.GetAxis(Vertical);
        _moverent.Move(_directionMover);

        _directionRotation.x = Input.GetAxis(MouseX);
        _directionRotation.y = Input.GetAxis(MouseY);
        _rotation.Rotate(_directionRotation);
    }
}