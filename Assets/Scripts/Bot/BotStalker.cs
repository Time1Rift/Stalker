using UnityEngine;

[RequireComponent(typeof(BotMover))]
public class BotStalker : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform; 
    [SerializeField, Min(0)] private float _stopRadius = 3f;

    private BotMover _mover;
    private Transform _transform;
    private Vector3 _direction;

    private void Awake()
    {
        _mover = GetComponent<BotMover>();
        _transform = transform;
    }

    private void Update()
    {
        _direction = _playerTransform.position - _transform.position;

        if (_direction.sqrMagnitude >= _stopRadius * _stopRadius)
            _mover.Move(_direction.normalized);
    }
}