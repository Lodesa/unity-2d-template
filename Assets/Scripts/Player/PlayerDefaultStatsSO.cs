using UnityEngine;

namespace Player {
  [CreateAssetMenu(fileName = "PlayerDefaultStats", menuName = "Scriptable Objects/PlayerDefaultStats", order = 1)]
  public class PlayerDefaultStatsSO : ScriptableObject {
    public float moveSpeed = 3;
  }
}