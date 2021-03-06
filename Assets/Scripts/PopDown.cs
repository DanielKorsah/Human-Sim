﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopDown : MonoBehaviour
{
    RectTransform rt;
    Vector3 downPos = new Vector3(0, 0, 0);
    Vector3 upPos = new Vector3(0, 1080, 0);
    bool isDown;

    void Start()
    {
        //get the recttransform of the sliding panel 
        rt = GetComponent<RectTransform>();
        SetUp();
    }

    void Update()
    {

        //toggle panel up or down with Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isDown)
            {
                SetDown();
            }
            else
            {
                SetUp();
            }

        }
    }

    public void SetDown()
    {
        rt.localPosition = downPos;
        isDown = true;
        Time.timeScale = 0;
    }

    public void SetUp()
    {
        rt.localPosition = upPos;
        isDown = false;
        Time.timeScale = 1;
    }
}