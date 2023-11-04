using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3((_cam.ScreenToWorldPoint(Input.mousePosition)/10).x, (_cam.ScreenToWorldPoint(Input.mousePosition) / 10).y,transform.position.z);
    }
}
