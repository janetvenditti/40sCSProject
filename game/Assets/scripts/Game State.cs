using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Object/GameState", order = 1)]
public class GameState : ScriptableObject
{
    public string playerSpawnLocation = "";
}
