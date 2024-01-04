using System;
using UIToolkit.Screens;
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
      TogglePauseScreen();
      InvokePause();
    }

    void ToggleTimeScale() {
      Time.timeScale = _isPaused ? 0f : 1f;
    }

    void TogglePauseScreen() {
      if (_isPaused) {
        ScreenManager.Instance.ShowScreen("MainMenu");
      }
      else {
        ScreenManager.Instance.HideAllScreens();
      }
    }
    
    void InvokePause() {
      OnTogglePause?.Invoke(_isPaused);
    }
  }
}