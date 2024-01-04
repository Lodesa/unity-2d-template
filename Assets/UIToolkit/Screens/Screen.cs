using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class Screen : MonoBehaviour {
  private string _name;
  private UIDocument _uiDocument;
  private Button _btnBack;

  void Start() {
    _uiDocument = GetComponent<UIDocument>();
    _name = _uiDocument.name;
    _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
  }
  
  void OnEnable() {
    ScreenManager.OnShowScreen += ShowScreen;
    ScreenManager.OnHideAllScreens += HideScreen;

    // Register back button handler
    _uiDocument = GetComponent<UIDocument>();
    if (_uiDocument) {
      _uiDocument.rootVisualElement.RegisterCallback<NavigationCancelEvent>(ShowPreviousScreen);
      _btnBack = _uiDocument.rootVisualElement.Q("btnBack") as Button;
      if (_btnBack != null) {
        _btnBack.clicked += ShowPreviousScreen;
      }
    }    
  }

  void OnDisable() {
    ScreenManager.OnShowScreen -= ShowScreen;
    ScreenManager.OnHideAllScreens -= HideScreen;
    
    // Unregister back button handler
    if (_btnBack != null) {
      _btnBack.clicked += ShowPreviousScreen;
    }    
  }

  void ShowScreen(string screen) {
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

  void ShowPreviousScreen(NavigationCancelEvent evt) {
    ShowPreviousScreen();
  }
  void ShowPreviousScreen() {
    ScreenManager.Instance.ShowPreviousScreen();
  }  
}