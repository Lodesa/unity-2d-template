using System;
using UnityEngine;

namespace Managers {
  public class PauseManager : Singleton<PauseManager> {
    private bool _isPaused;

    public static event Action<bool> OnTogglePause;

    void Awake() {
      _isPaused = false;
    }

    public void TogglePauseState() {
      _isPaused = !_isPaused;
      ToggleTimeScale();
      InvokePause();
    }

    void ToggleTimeScale() {
      Time.timeScale = _isPaused ? 0f : 1f;
    }

    void InvokePause() {
      OnTogglePause?.Invoke(_isPaused);
    }
  }
}