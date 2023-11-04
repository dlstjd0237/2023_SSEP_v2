using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DialogSystemSO")]

public class DialogSystemSO : ScriptableObject
{
    [Header("Ȧ��ĭ���� ���ϴ��� ¦��ĭ���� ����")]
    public List<string> Info;
    [Header("�̹����� �ٲ�� ĭ���ٰ� �� ������")]
    public List<Sprite> SpriteList;
}
