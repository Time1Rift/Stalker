using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(MoverentPhysics))]
public class PlayerMoverent : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed = 8f;
    [SerializeField, Min(0f)] private float _strafeSpeed = 7f;

    private CharacterController _characterController;
    private MoverentPhysics _moverentPhysics;
    private Vector3 _verticalVelocity;
    private Vector3 _horizontalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _moverentPhysics = GetComponent<MoverentPhysics>();
    }

    public void Move(Vector3 direction)
    {
        direction = _moverentPhysics.Forward * direction.z * _speed + _moverentPhysics.Right * direction.x * _strafeSpeed;

        if (_characterController.isGrounded)
        {
            _verticalVelocity = Vector3.down;
            _characterController.Move((direction + _verticalVelocity) * Time.deltaTime);
        }
        else
        {
            _horizontalVelocity = _characterController.velocity;
            _horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity;
            _characterController.Move((_horizontalVelocity + _verticalVelocity) * Time.deltaTime);
        }
    }
}