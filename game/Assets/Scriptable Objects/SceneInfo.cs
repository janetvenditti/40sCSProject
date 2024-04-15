using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence", order = 1)]

public class SceneInfo : ScriptableObject
{ 
  public bool isNextScene = true;
}
