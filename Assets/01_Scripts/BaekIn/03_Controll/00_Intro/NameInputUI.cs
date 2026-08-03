using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class NameInputUI : MonoBehaviour
{
    private UIDocument _doc;
    private TextField _inputField;
    private Label _errorLabel;
    private Button _submitBtn;
    private VisualElement _contain;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        Init();
        _submitBtn.RegisterCallback<ClickEvent>(Complit);
    }
    

    private void Complit(ClickEvent evt)
    {
        if(_inputField.value.Length > 8||_inputField.value == "")
        {
            _errorLabel.text = "Name Clamp(name,0,8)";
            return;
        }
        _errorLabel.text = string.Empty;
        _contain.AddToClassList("on");
        GameManger.Instance.PlayerName = _inputField.value;

    }

    private void Init()
    {
        var _root = _doc.rootVisualElement;
        _inputField = _root.Q<TextField>("inputname-textfield");
        _submitBtn = _root.Q<Button>("submit-btn");
        _errorLabel = _root.Q<Label>("error-label");
        _contain = _root.Q<VisualElement>("contain-box");

    }



}
