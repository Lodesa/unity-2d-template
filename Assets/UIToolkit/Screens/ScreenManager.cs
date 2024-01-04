using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager> {
  private Dictionary<string, GameObject> _screens;
  private Stack<string> _breadCrumbs;
  
  public static event Action<string> OnShowScreen;
  public static event Action OnHideAllScreens;

  void Awake() {
    _breadCrumbs = new Stack<string>();
  }

  // SHOW
  public void ShowScreen(string screen) {
    InvokeShowScreen(screen);
  }
  void InvokeShowScreen(string screen) {
    _breadCrumbs.Push(screen);
    OnShowScreen?.Invoke(screen);
  }

  // HIDE ALL
  public void HideAllScreens() {
    _breadCrumbs.Clear();
    InvokeHideAllScreens();
  }
  void InvokeHideAllScreens() {
    OnHideAllScreens?.Invoke();
  }
  
  // PREVIOUS
  public void ShowPreviousScreen() {
    if (_breadCrumbs.Count >= 2) {
      _breadCrumbs.Pop();
      string prev = _breadCrumbs.Peek();
      OnShowScreen?.Invoke(prev);
    }
  }
}