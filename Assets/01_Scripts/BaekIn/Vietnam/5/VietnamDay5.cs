using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VietnamDay5 : MonoBehaviour
{
    [Header("예시 SO/Vietnam/Vietanam1Day")]
    [SerializeField] private string _pathSO;
    [Header("선택창 버튼 글")]
    [SerializeField] private List<string> _choice = new();
    [Header("선택하면 넘어갈 씬")]
    [SerializeField] private string _nextScene;
    [Header("어떤걸 ")]
    [SerializeField] private List<bool> Completion = new();
    private void Start()
    {
        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>(_pathSO), OnBtn);
    }
    private void OnBtn()
    {
        DialogSystem.Instance.ButtonNameSet(_choice[0], _choice[1], _choice[2]);
        DialogSystem.Instance.ButtonActionSet(
            () => { GameManger.Instance.Vietnam5 = Completion[0]; GameManger.Instance.Point += GameManger.Instance.Vietnam5 == false ? -3 : +5; SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(_nextScene)); },
            () => { GameManger.Instance.Vietnam5 = Completion[1]; GameManger.Instance.Point += GameManger.Instance.Vietnam5 == false ? -3 : +5; SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(_nextScene)); },
            () => { GameManger.Instance.Vietnam5 = Completion[2]; GameManger.Instance.Point += GameManger.Instance.Vietnam5 == false ? -3 : +5; SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(_nextScene)); });
    }
}
