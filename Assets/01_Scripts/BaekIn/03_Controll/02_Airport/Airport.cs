using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Airport : MonoBehaviour
{
    private void Awake()
    {

        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>("SO/02_Airport1"), ShowChoice);

    }
    public void ShowChoice()
    {
        DialogSystem.Instance.ButtonNameSet("Vietnam\n(Ease)", "Italia\n(Normal)", "Canada\n(Hard)");
        DialogSystem.Instance.ButtonActionSet(
            () =>
            {
                GameManger.Instance.CurrentCountry = "Vietnam";
                OnChoice();
            },
            () =>
            {
                GameManger.Instance.CurrentCountry = "Italia";
                OnChoice();
            },
            () =>
            {
                GameManger.Instance.CurrentCountry = "Canada";
                OnChoice();
            });
    }

    private void OnChoice()
    {
        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>("SO/02_Airport2"),()=>SceneLoadManager.Instance.FadeOut(()=>SceneManager.LoadScene(GameManger.Instance.CurrentCountry)));
    }
}
