using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class Screen : MonoBehaviour {
  private string _name;
  private UIDocument _uiDocument;

  void Awake() {
    _uiDocument = GetComponent<UIDocument>();
    _name = _uiDocument.name;
    _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
  }
  
  void OnEnable() {
    ScreenManager.OnShowScreen += ShowScreen;
    ScreenManager.OnHideAllScreens += HideScreen;
  }

  void OnDisable() {
    ScreenManager.OnShowScreen -= ShowScreen;
    ScreenManager.OnHideAllScreens -= HideScreen;
  }

  void ShowScreen(string screen) {
    // _uiDocument.enabled = screen == _name;
    if (screen == _name) {
      _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
    else {
      HideScreen();
    }
  }

  void HideScreen() {
    _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
  }
}