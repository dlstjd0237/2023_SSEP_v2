using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VietnamDay3End : MonoBehaviour
{
    [Header("���ǿ���SO�ּ�")]
    [SerializeField] private string _badPathSO;
    [Header("��忣��SO�ּ�")]
    [SerializeField] private string _goodPathSO;
    [Header("���� ���� �Ѿ �� �̸�")]
    [SerializeField] private string nextScene;

    private void Start()
    {
        if (GameManger.Instance.Vietnam3 == false)
            DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>(_badPathSO), () => SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(nextScene)));
        else
        {
            DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>(_goodPathSO), () => SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(nextScene)));
        }
    }
}