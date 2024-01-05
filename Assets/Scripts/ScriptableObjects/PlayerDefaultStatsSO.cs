using UnityEngine;

namespace ScriptableObjects {
  [CreateAssetMenu(fileName = "PlayerDefaultStats", menuName = "Scriptable Objects/PlayerDefaultStats", order = 1)]
  public class PlayerDefaultStatsSO : ScriptableObject {
    public float hitPoints = 100;
    public float moveSpeed = 3;
  }
}