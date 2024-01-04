using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
  private Button _btnSubMenu1;
  private VisualElement _veMainMenu;
  private VisualElement _veSubMenu1;

  private void OnEnable() {
    var uiDocument = GetComponent<UIDocument>();

    _veMainMenu = uiDocument.rootVisualElement.Q("veMainMenu") as VisualElement;
    _veSubMenu1 = uiDocument.rootVisualElement.Q("veSubMenu1") as VisualElement;
    _btnSubMenu1 = uiDocument.rootVisualElement.Q("btnSubMenu1") as Button;

    if (_btnSubMenu1 != null) {
      _btnSubMenu1.RegisterCallback<ClickEvent>(PrintClickMessage);
      _btnSubMenu1.RegisterCallback<NavigationSubmitEvent>(PrintClickMessage);
      // _btnSubMenu1.clicked += PrintClickMessage;

      _btnSubMenu1.Focus();
    }
  }

  private void OnDisable() {
    _btnSubMenu1.UnregisterCallback<ClickEvent>(PrintClickMessage);
    _btnSubMenu1.UnregisterCallback<NavigationSubmitEvent>(PrintClickMessage);
    // _btnSubMenu1.clicked -= PrintClickMessage;
  }

  private void PrintClickMessage(ClickEvent evt) {
    print("click");
  }
  
  private void PrintClickMessage(NavigationSubmitEvent evt) {
    print("click");
  }  
}