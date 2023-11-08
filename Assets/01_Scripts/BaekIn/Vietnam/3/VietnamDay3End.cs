using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VietnamDay3End : MonoBehaviour
{
    [Header("해피엔딩SO주소")]
    [SerializeField] private string _badPathSO;
    [Header("배드엔딩SO주소")]
    [SerializeField] private string _goodPathSO;
    [Header("다음 으로 넘어갈 씬 이름")]
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
