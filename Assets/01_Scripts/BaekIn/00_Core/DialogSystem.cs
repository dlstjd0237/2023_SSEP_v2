using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogSystem : MonoBehaviour
{
    [SerializeField] private float TextTyping;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _currentSpeakingText;
    private DialogSystemSO currentSO;

    private void Awake()
    {
        currentSO = Resources.Load<DialogSystemSO>("SO/1");
        StartCoroutine(SetText(currentSO.Info));
    }

    public void ShowTextBar(DialogSystemSO dialogSystemSO)
    {
        currentSO = dialogSystemSO;
    }

 

    private IEnumerator SetText(List<string> textList)
    {
        var Wait = new WaitForSeconds(0.25f);
        int nameCount = 0;
        for (int i = 0; i < textList.Count / 2; i++)
        {
            _currentSpeakingText.SetText("");
           var a = textList[nameCount];
            _currentSpeakingText.SetText(a);
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
                }
                yield return Wait;
            }
            nameCount++;

        }

    }
}
