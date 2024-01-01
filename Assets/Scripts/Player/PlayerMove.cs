using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour {
  public float movementSpeed = 3f;
  // public float accelerationTime = 0.4f;

  private Vector2 _movementDirection;
  private Rigidbody2D _rb;
  private float _velXSmoothing;
  private float _velYSmoothing;

  void Start() {
    _rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate() {
    _rb.velocity = _movementDirection * movementSpeed;
    // Vector3 movement = _movementDirection * (movementSpeed * Time.deltaTime);
    // _rb.MovePosition(transform.position + movement);

    // float velY = Mathf.SmoothDamp(_rb.velocity.y, _movementDirection.y * movementSpeed, ref _velXSmoothing, accelerationTime);
    // float velX = Mathf.SmoothDamp(_rb.velocity.x, _movementDirection.x * movementSpeed, ref _velYSmoothing, accelerationTime);
    // _rb.velocity = new Vector2(velX, velY);  
  }

  public void UpdateMovementDirection(Vector3 direction) {
    _movementDirection = direction;
  }
}