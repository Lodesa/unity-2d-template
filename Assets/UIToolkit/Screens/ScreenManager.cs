using System;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager> {
  private string _currentScreen;

  public static event Action<string> OnShowScreen;
  public static event Action OnHideAllScreens;

  void Awake() {
    _currentScreen = null;
  }

  public void ShowScreen(string screen) {
    _currentScreen = screen;
    InvokeShowScreen(screen);
  }

  void InvokeShowScreen(string screen) {
    OnShowScreen?.Invoke(screen);
  }

  public void HideAllScreens() {
    _currentScreen = null;
    InvokeHideAllScreens();
  }

  void InvokeHideAllScreens() {
    OnHideAllScreens?.Invoke();
  }
}