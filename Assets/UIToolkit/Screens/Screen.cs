using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace UIToolkit.Screens {
  
  [RequireComponent(typeof(UIDocument))]
  public class Screen : MonoBehaviour {
    public PanelSettings panelSettings;
    private UIDocument _uiDocument;
    private Button _btnBack;

    void Start() {
      ScreenManager.Instance.RegisterScreen(gameObject);
    }

    void OnEnable() {
      EventSystemFindGameObject();

      _uiDocument = GetComponent<UIDocument>();
      if (_uiDocument) {
        _uiDocument.rootVisualElement.Q<Button>().Focus();
        _uiDocument.rootVisualElement.RegisterCallback<NavigationCancelEvent>(ShowPreviousScreen);
        _btnBack = _uiDocument.rootVisualElement.Q("btnBack") as Button;
        if (_btnBack != null) {
          _btnBack.clicked += ShowPreviousScreen;
        }
      }
    }

    void OnDisable() {
      if (_btnBack != null) {
        _btnBack.clicked += ShowPreviousScreen;
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