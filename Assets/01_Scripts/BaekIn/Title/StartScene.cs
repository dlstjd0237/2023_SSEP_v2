using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour
{
    private Color _cr;
    [SerializeField] private TextMeshProUGUI _toych;
    private bool _isStart;
    [SerializeField] private string NextScene;
    private void Start()
    {
        StartCoroutine(TextFadeOut());
    }

    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame && _isStart == false)
        {
            _isStart = true;
            SceneLoadManager.Instance.FadeOut(() => SceneManager.LoadScene(NextScene));
        }
    }

    private IEnumerator TextFadeOut()
    {
        _cr = _toych.color;
        while (_toych.color.a <= 1)
        {
            _cr.a += Time.deltaTime / 2f;
            _toych.color = _cr;
            yield return null;
        }
        StartCoroutine(TextFadeIn());
    }
    private IEnumerator TextFadeIn()
    {
        _cr = _toych.color;
        while (_toych.color.a >= 0)
        {
            _cr.a -= Time.deltaTime / 2f;
            _toych.color = _cr;
            yield return null;
        }
        StartCoroutine(TextFadeOut());
    }
}
