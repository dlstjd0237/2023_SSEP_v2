using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VietnamDay1 : MonoBehaviour
{
    private void Start()
    {
        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>("SO/Vietnam/Vietanam1Day"), OnBtn);
    }
    private void OnBtn()
    {
        DialogSystem.Instance.ButtonNameSet("black", "pink", "white");
        DialogSystem.Instance.ButtonActionSet(
            () => { GameManger.Instance.Vietnam1 = false; GameManger.Instance.Point += -3; },
            () => { GameManger.Instance.Vietnam1 = true; GameManger.Instance.Point += 5; },
            () => { GameManger.Instance.Vietnam1 = true; GameManger.Instance.Point += 5; });
    }
}
