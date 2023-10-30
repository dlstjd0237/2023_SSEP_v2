using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
public class DialogSystem : MonoBehaviour
{
    [SerializeField] private float TextTyping;

    private UIDocument _doc;

    private Label _infoText;
    private Label _currentSpeakingText;

    private DialogSystemSO currentSO;

    private void Awake()
    {

        _doc = GetComponent<UIDocument>();
        var _root = _doc.rootVisualElement;

        _infoText = _root.Q<Label>("info-label");
        _currentSpeakingText = _root.Q<Label>("name-label");

        currentSO = Resources.Load<DialogSystemSO>("SO/1");
        StartCoroutine(SetText(currentSO.Info));
    }

    public void ShowTextBar(DialogSystemSO dialogSystemSO)
    {
        currentSO = dialogSystemSO;
    }



    private IEnumerator SetText(List<string> textList)
    {
        var Wait = new WaitForSeconds(TextTyping); //타입핑 속도
        int nameCount = 0; 
        for (int i = 0; i < textList.Count / 2; i++)
        {
            _currentSpeakingText.text = "";
            var a = textList[nameCount];
            _currentSpeakingText.text = a;
            nameCount++;
            _infoText.text = "";

            string text = textList[nameCount];
            int count = 0;
            while (count != text.Length)
            {
                if (count < text.Length)
                {
                    _infoText.text += text[count].ToString();
                    count++;
                    yield return Wait;
                }
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            nameCount++;

        }

    }
}
