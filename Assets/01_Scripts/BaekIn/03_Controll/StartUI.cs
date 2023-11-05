using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{
    private UIDocument _doc;

    private Label _currentDayLabel;
    [SerializeField] private string path;
    [SerializeField] private string nextScene;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        var _root = _doc.rootVisualElement;
        _currentDayLabel = _root.Q<Label>("currentday-label");
        GameManger.Instance.ToDay++;
        _currentDayLabel.text = $"{GameManger.Instance.CurrentCountry}\n{GameManger.Instance.ToDay.ToString()} Day";
        _currentDayLabel.RemoveFromClassList("on");
        Invoke("Hiden", 3);
    }

    private void Hiden()
    {
        _currentDayLabel.AddToClassList("on");
        DialogSystem.Instance.ShowTextBar(Resources.Load<DialogSystemSO>(path),()=>SceneLoadManager.Instance.FadeOut(()=>SceneManager.LoadScene(nextScene)));
    }

}
