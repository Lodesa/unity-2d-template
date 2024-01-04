using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
  private Button _btnAudio;
  private Button _btnController;
  
  private void OnEnable() {
    var uiDocument = GetComponent<UIDocument>();

    if (uiDocument) {
      uiDocument.rootVisualElement.Focus();

      _btnAudio = uiDocument.rootVisualElement.Q("btnAudio") as Button;
      if (_btnAudio != null) {
        _btnAudio.clicked += ShowAudioMenu;
      }

      _btnController = uiDocument.rootVisualElement.Q("btnController") as Button;
      if (_btnController != null) {
        _btnController.clicked += ShowControllerMenu;
      }
    }
  }

  void OnDisable() {
    _btnAudio.clicked -= ShowAudioMenu;
    _btnController.clicked -= ShowControllerMenu;    
  }

  void ShowAudioMenu() {
    ScreenManager.Instance.ShowScreen("AudioMenu");
  }

  void ShowControllerMenu() {
    ScreenManager.Instance.ShowScreen("ControllerMenu");
  }
}