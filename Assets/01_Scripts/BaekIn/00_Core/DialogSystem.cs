using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System;
public class DialogSystem : MonoSingleton<DialogSystem>
{
    [SerializeField] private float TextTyping;

    private UIDocument _doc;

    private Label _infoText;
    private Label _currentSpeakingText;
    private VisualElement _containBox;
    private VisualElement _backgroundBox;
    private DialogSystemSO currentSO;

    private VisualElement _btnBox;
    private Button _firstButton;
    private Button _secondButton;
    private Button _thirdButton;

    private List<Action> _buttonAction = new();
    private void OnEnable()
    {
        Init();
        _containBox.AddToClassList("on");

    }
    private void Init()
    {
        _doc = GetComponent<UIDocument>();

        var _root = _doc.rootVisualElement;

        _containBox = _root.Q<VisualElement>("contain");

        _infoText = _root.Q<Label>("info-label");
        _currentSpeakingText = _root.Q<Label>("name-label");
        _backgroundBox = _root.Q<VisualElement>("background-box");

        _btnBox = _root.Q<VisualElement>("btn-box");
        _firstButton = _root.Q<Button>("1-btn");
        _secondButton = _root.Q<Button>("2-btn");
        _thirdButton = _root.Q<Button>("3-btn");
        for (int i = 0; i < 3; ++i)
        {
            _buttonAction.Add(() => Debug.Log("ddd"));
        }
        _firstButton.clicked += () => CloseBtnBox();
        _secondButton.clicked += () => CloseBtnBox();
        _thirdButton.clicked += () => CloseBtnBox();
    }


    public void ButtonActionSet(Action action1, Action action2, Action action3)
    {
        if (_buttonAction != null)// 버튼 액션이 존재한다면
        {
            _firstButton.clicked -= _buttonAction[0];
            _secondButton.clicked -= _buttonAction[1];
            _thirdButton.clicked -= _buttonAction[2];
        }
        _buttonAction[0] = action1;
        _buttonAction[1] = action2;
        _buttonAction[2] = action3;

        _firstButton.clicked += _buttonAction[0];
        _secondButton.clicked += _buttonAction[1];
        _thirdButton.clicked += _buttonAction[2];
        OpenBtnBox();
    }

    public void OpenBtnBox()
    {
        _btnBox.RemoveFromClassList("on");
        _firstButton.pickingMode = PickingMode.Position;
        _secondButton.pickingMode = PickingMode.Position;
        _thirdButton.pickingMode = PickingMode.Position;
        _btnBox.pickingMode = PickingMode.Position;
    }
    public void CloseBtnBox()
    {
        _btnBox.AddToClassList("on");
        _firstButton.pickingMode = PickingMode.Ignore;
        _secondButton.pickingMode = PickingMode.Ignore;
        _thirdButton.pickingMode = PickingMode.Ignore;
        _btnBox.pickingMode = PickingMode.Ignore;
    }


    public void ShowTextBar(DialogSystemSO dialogSystemSO)
    {
        //Init();
        _containBox.RemoveFromClassList("on");
        currentSO = dialogSystemSO;
        StartCoroutine(SetText(currentSO.Info, currentSO.SpriteList));

    }
    public void ShowTextBar(DialogSystemSO dialogSystemSO, Action action)
    {
        //Init();
        _containBox.RemoveFromClassList("on");
        currentSO = dialogSystemSO;
        StartCoroutine(SetText(currentSO.Info, currentSO.SpriteList, action));

    }




    private IEnumerator SetText(List<string> textList, List<Sprite> sprite) //액션 없는 놈
    {
        var Wait = new WaitForSeconds(TextTyping); //타입핑 속도
        int nameCount = 0;
        for (int i = 0; i < textList.Count / 2; i++)
        {
            if (sprite[i] == null)
                _backgroundBox.style.backgroundImage = StyleKeyword.None;
            else
                _backgroundBox.style.backgroundImage = sprite[i].texture;
            //_currentSpeakingText.text = "";
            var a = textList[nameCount];
            if (a == "나")
                a = GameManger.Instance.PlayerName;
            _currentSpeakingText.text = a;
            nameCount++;
            _infoText.text = "";

            string text = textList[nameCount];
            int count = 0;
            while (count != text.Length)
            {
                if (count < text.Length)
                {

                    if (text[count].ToString() == "`")
                        _infoText.text += $"\n";
                    else if (text[count].ToString() == "\\")
                        _infoText.text += $"{GameManger.Instance.CurrentCountry}";
                    else
                        _infoText.text += text[count].ToString();
                    count++;
                    yield return Wait;
                }
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            nameCount++;

        }

        _containBox.AddToClassList("on");

    }

    private IEnumerator SetText(List<string> textList, List<Sprite> sprite, Action action) //액션있는 놈
    {
        var Wait = new WaitForSeconds(TextTyping); //타입핑 속도
        int nameCount = 0;
        for (int i = 0; i < textList.Count / 2; i++)
        {
            if (sprite[i] == null)
                _backgroundBox.style.backgroundImage = StyleKeyword.None;
            else
                _backgroundBox.style.backgroundImage = sprite[i].texture;
            //_currentSpeakingText.text = "";
            var a = textList[nameCount];
            if (a == "나")
                a = GameManger.Instance.PlayerName;
            _currentSpeakingText.text = a;
            nameCount++;
            _infoText.text = "";

            string text = textList[nameCount];
            int count = 0;
            while (count != text.Length)
            {
                if (count < text.Length)
                {

                    if (text[count].ToString() == "`")
                        _infoText.text += $"\n";
                    else if (text[count].ToString() == "\\")
                        _infoText.text += $"{GameManger.Instance.CurrentCountry}";
                    else
                        _infoText.text += text[count].ToString();
                    count++;
                    yield return Wait;
                }
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            nameCount++;

        }
        action?.Invoke();
        _containBox.AddToClassList("on");

    }

    private IEnumerator SetText(List<string> textList, Action StartAction, Action endAction) // 액션 2개인놈
    {
        var Wait = new WaitForSeconds(TextTyping); //타입핑 속도
        int nameCount = 0;
        StartAction?.Invoke();
        for (int i = 0; i < textList.Count / 2; i++)
        {
            //_currentSpeakingText.text = "";
            var a = textList[nameCount];
            if (a == "나")
                a = GameManger.Instance.PlayerName;
            _currentSpeakingText.text = a;
            nameCount++;
            _infoText.text = "";

            string text = textList[nameCount];
            int count = 0;
            while (count != text.Length)
            {
                if (count < text.Length)
                {
                    if (text[count].ToString() == "`")
                        _infoText.text += $"\n";
                    else if (text[count].ToString() == "\\")
                        _infoText.text += $"{GameManger.Instance.CurrentCountry}";
                    else
                        _infoText.text += text[count].ToString();
                    count++;
                    yield return Wait;
                }
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            nameCount++;

        }
        endAction?.Invoke();
        _containBox.AddToClassList("on");

    }
    public void ButtonNameSet(string name1, string name2, string name3)
    {
        _firstButton.text = name1;
        _secondButton.text = name2;
        _thirdButton.text = name3;
    }
}
