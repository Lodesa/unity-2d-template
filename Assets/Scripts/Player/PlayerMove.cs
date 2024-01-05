using Managers;
using UnityEngine;

namespace Player {
  
  [RequireComponent(typeof(Rigidbody2D))]
  public class PlayerMove : MonoBehaviour {
    private Vector2 _movementDirection;
    private Rigidbody2D _rb;
    private float _velXSmoothing;
    private float _velYSmoothing;

    void Start() {
      _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
      _rb.velocity = _movementDirection * SOManager.Instance.playerDefaultStats.moveSpeed;
    }

    public void UpdateMovementDirection(Vector3 direction) {
      _movementDirection = direction;
    }
  }
}