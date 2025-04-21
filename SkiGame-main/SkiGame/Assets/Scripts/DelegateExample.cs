using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    public delegate void DelegateEx();
    private DelegateEx function;

    private void Start()
    {
        function = Example1;
        function();
        function = Example2;
        function();
    }

    private void Example1()
    {
        Debug.Log("Hello");
    }
    
    private void Example2()
    {
        Debug.Log("Goodbye");
    }

}
