using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoSingleton<GameManger>
{
    public string PlayerName { get; set; }
    public string CurrentCountry { get; set; }

    public int ToDay = 0;
}
