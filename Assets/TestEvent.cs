using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour
{
    [Serializable]
    public class MyEvent : UnityEvent<int> { }
    public MyEvent OnClicked;
    // Start is called before the first frame update
    public int a;
    void Start()
    {
        a = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked.Invoke(a);
        }
    }

    public void TestClick(int b)
    {
        print(b);
    }
}
