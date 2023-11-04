using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroControll : MonoBehaviour
{
    [SerializeField]private string _nextScene;

    private void Start()
    {
        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>("SO/Intro"), () => SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(_nextScene))); ;
    }
}
