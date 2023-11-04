using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DialogSystemSO")]

public class DialogSystemSO : ScriptableObject
{
    [Header("홀수칸에는 말하는이 짝수칸에는 내용")]
    public List<string> Info;
    [Header("이미지가 바뀌는 칸에다가 만 넣으셈")]
    public List<Sprite> SpriteList;
}
