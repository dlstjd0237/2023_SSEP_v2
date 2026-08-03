using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoSingleton<GameManger>
{
    public string PlayerName { get; set; }
    public string CurrentCountry { get; set; }

    public int ToDay = 0;
    public int Point = 0;

    public bool Vietnam1 { get; set; }
    public bool Vietnam2 { get; set; }
    public bool Vietnam3 { get; set; }
    public bool Vietnam4 { get; set; }
    public bool Vietnam5 { get; set; }


}
