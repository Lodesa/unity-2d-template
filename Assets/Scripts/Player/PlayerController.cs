using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
  
  [
    RequireComponent(typeof(PlayerMove)),
    RequireComponent(typeof(PlayerInput))
  ]
  public class PlayerController : MonoBehaviour {
    private PlayerInput _playerInput;
    private PlayerMove _playerMove;

    private string _actionMapPlayerControls = "Player";
    private string _actionMapMenuControls = "UI";
    private Vector3 _rawInputMovement;

    void OnEnable() {
      Managers.PauseManager.OnTogglePause += TogglePause;
    }
    void OnDisable() {
      Managers.PauseManager.OnTogglePause -= TogglePause;
    }

    void Start() {
      _playerInput = GetComponent<PlayerInput>();
      _playerMove = GetComponent<PlayerMove>();
    }

    // PlayerInput event handlers
    // ========================================================================
    public void OnTogglePause(InputAction.CallbackContext value)
    {
      if (value.started)
      {
        Managers.PauseManager.Instance.TogglePauseState();
      }
    }

    // OnMove
    public void OnMove(InputAction.CallbackContext value) {
      Vector2 inputMovement = value.ReadValue<Vector2>();
      _rawInputMovement = new Vector3(inputMovement.x, inputMovement.y, 0);
      _playerMove.UpdateMovementDirection(_rawInputMovement);
    }

    // PauseManager event handlers
    // ========================================================================
    private void TogglePause(bool isPaused) {
      if (isPaused) {
        _playerInput.SwitchCurrentActionMap(_actionMapMenuControls);
      }
      else {
        _playerInput.SwitchCurrentActionMap(_actionMapPlayerControls);
      }
    }
  }
}