using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace UIToolkit {
  public class EventSystemManager : Singleton<EventSystemManager> {
    private bool _isPaused;
    public PanelSettings panelSettings;
    public GameObject screens;

    private void Awake() {
      ActivateUIScreens();
    }

    // make input system work without having to click game screen first
    public void SetSelectedGameObject() {
      if (EventSystem.current != null)
        EventSystem.current.SetSelectedGameObject(EventSystem.current.transform.Find(panelSettings.name).gameObject);      
    }
    
    // set UIScreens game object to active (inactive in editor mode to hide all UI screens by default)
    public void ActivateUIScreens() {
      if (screens != null) {
        screens.SetActive(true);
      }
    }
  }
}