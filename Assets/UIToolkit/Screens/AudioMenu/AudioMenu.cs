using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkit.Screens.AudioMenu {
  
  public class AudioMenu : MonoBehaviour {
    private Button _btnBack;
  
    private void OnEnable() {
      var uiDocument = GetComponent<UIDocument>();
    }
  }
}