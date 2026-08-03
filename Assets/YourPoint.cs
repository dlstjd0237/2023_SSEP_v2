using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class YourPoint : MonoBehaviour
{
    private TextMeshProUGUI _point;
    private void Awake()
    {
        _point = GetComponent<TextMeshProUGUI>();
        _point.SetText($"your point : {GameManger.Instance.Point.ToString()}");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
