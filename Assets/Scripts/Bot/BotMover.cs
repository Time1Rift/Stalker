using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMover : MonoBehaviour
{
    [SerializeField, Min(0)] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;
    private Vector3 _offset;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _offset = direction * _moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + _offset);
    }
}