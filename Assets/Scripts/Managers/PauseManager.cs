using System;
using UnityEngine;

namespace Managers {
  public class PauseManager : Singleton<PauseManager> {
    private bool isPaused;

    public static event Action<bool> OnTogglePause;

    void Awake() {
      isPaused = false;
    }

    public void TogglePauseState() {
      isPaused = !isPaused;
      ToggleTimeScale();
      InvokePause();
    }

    void ToggleTimeScale() {
      Time.timeScale = isPaused ? 0f : 1f;
    }

    void InvokePause() {
      OnTogglePause?.Invoke(isPaused);
    }
  }
}