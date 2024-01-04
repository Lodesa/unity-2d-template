using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

class EventSystemSelectionInitializer : MonoBehaviour
{
  public PanelSettings panelSettings; // drag your PanelSettings here in the inspector
  void Start()
  {
    if (EventSystem.current != null)
      EventSystem.current.SetSelectedGameObject(EventSystem.current.transform.Find(panelSettings.name).gameObject);
  }
}