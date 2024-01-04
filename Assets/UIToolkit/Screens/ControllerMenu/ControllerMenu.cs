using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkit.Screens.ControllerMenu {
  
  public class ControllerMenu : MonoBehaviour {
    private Button _btnBack;
  
    private void OnEnable() {
      var uiDocument = GetComponent<UIDocument>();
    }
  }
}