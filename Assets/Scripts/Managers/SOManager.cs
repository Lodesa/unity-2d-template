using System;
using Player;
using ScriptableObjects;
using UIToolkit.Screens;
using UnityEngine;

namespace Managers {
  public class SOManager : Singleton<SOManager> {
    public PlayerDefaultStatsSO playerDefaultStats;
  }
}