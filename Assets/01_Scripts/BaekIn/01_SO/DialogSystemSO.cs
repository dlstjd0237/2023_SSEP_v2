using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DialogSystemSO")]

public class DialogSystemSO : ScriptableObject
{
    [Header("이런식으로 적어야함 홀수칸에는 말하는이 짝수칸에는 내용")]
    public List<string> Info;
}
