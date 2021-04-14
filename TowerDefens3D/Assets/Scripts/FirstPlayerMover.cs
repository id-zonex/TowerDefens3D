using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FirstPlayerMover : PlayerMover
{
    [SerializeField] private float _speed = 4f;

    [SerializeField] private float _sensivity = 5f;

    private Rigidbody _rb;

    private Vector3 _rotateVelocity;
    private Vector3 _moveVelocity;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        _moveVelocity.x = Input.GetAxis("Horizontal");
        _moveVelocity.z = Input.GetAxis("Vertical");

        _rb.AddRelativeForce(_moveVelocity * _speed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        _rotateVelocity.x += Input.GetAxis("Mouse X");
        _rotateVelocity.y += Input.GetAxis("Mouse Y");

        _rotateVelocity.y = Mathf.Clamp(_rotateVelocity.y, -5, 10);

        transform.rotation = Quaternion.Euler(-_rotateVelocity.y, _rotateVelocity.x * _sensivity * Time.fixedDeltaTime, 0f);

    }

    protected override void ControleUpdate()
    {
        Rotate();
    }

    protected override void ControleFixedUpdate()
    {
        Move();
    }
}
