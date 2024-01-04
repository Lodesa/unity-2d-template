using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace UIToolkit.Screens {
  
  [RequireComponent(typeof(UIDocument))]
  public class Screen : MonoBehaviour {
    public PanelSettings panelSettings;
    private Button _btnBack;

    void Start() {
      ScreenManager.Instance.RegisterScreen(gameObject);
    }

    void OnEnable() {
      EventSystemFindGameObject();
      InitializeBackButton();
    }

    void OnDisable() {
      if (_btnBack != null) {
        _btnBack.clicked += ShowPreviousScreen;
      }
    }

    void InitializeBackButton() {
      UIDocument uiDocument = GetComponent<UIDocument>();
      if (uiDocument) {
        uiDocument.rootVisualElement.RegisterCallback<NavigationCancelEvent>(ShowPreviousScreen);
        _btnBack = uiDocument.rootVisualElement.Q("btnBack") as Button;
        if (_btnBack != null) {
          _btnBack.clicked += ShowPreviousScreen;
        }
      }
    }
    
    void ShowPreviousScreen(NavigationCancelEvent evt) {
      ShowPreviousScreen();
    }

    void ShowPreviousScreen() {
      ScreenManager.Instance.ShowPreviousScreen();
    }

    void EventSystemFindGameObject() {
      if (EventSystem.current != null)
        EventSystem.current.SetSelectedGameObject(EventSystem.current.transform.Find(panelSettings.name).gameObject);
    }
  }
}