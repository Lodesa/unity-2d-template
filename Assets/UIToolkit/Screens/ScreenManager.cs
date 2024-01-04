using System.Collections.Generic;
using UnityEngine;

namespace UIToolkit.Screens {
  
  public class ScreenManager : Singleton<ScreenManager> {
    private Dictionary<string, GameObject> _screens;
    private Stack<string> _breadCrumbs;

    private void Awake() {
      _screens = new Dictionary<string, GameObject>();
      _breadCrumbs = new Stack<string>();
    }

    public void RegisterScreen(GameObject go) {
      _screens.Add(go.name, go);
      go.SetActive(false);
    }

    public void ShowScreen(string screen) {
      if (_screens[screen] != null) {
        if (_breadCrumbs.Count > 0) {
          string curr = _breadCrumbs.Peek();
          _screens[curr].SetActive(false);
        }

        _breadCrumbs.Push(screen);
        _screens[screen].SetActive(true);
      }
    }

    public void HideAllScreens() {
      _breadCrumbs.Clear();
      foreach (var (key, value) in _screens) {
        value.SetActive(false);
      }
    }

    public void ShowPreviousScreen() {
      if (_breadCrumbs.Count >= 2) {
        string curr = _breadCrumbs.Pop();
        _screens[curr].SetActive(false);
        string prev = _breadCrumbs.Peek();
        _screens[prev].SetActive(true);
      }
    }
  }
}