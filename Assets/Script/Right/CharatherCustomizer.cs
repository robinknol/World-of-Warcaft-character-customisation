﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharatherCustomizer : MonoBehaviour
{
    private float xPos = 666;
    private float yPos = 110;
    private int numberTest = 1;
    public int diffrence;
    public Text numberCounter;
    public List<RawImage> images;
    public List<GameObject> things;
    private void Start()
    {
        for (int i = 0; i < images.Count; i++)
        {
            yPos -= diffrence;

            images[i].transform.localPosition = new Vector2(xPos, yPos);
        }
    }

    private void Update()
    {
        Debug.Log(images.Count);
        numberCounter.text = numberTest.ToString();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (images[images.Count - 1].transform.localPosition.y != 10)
            {
                numberTest += 1;
                Position(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (images[0].transform.localPosition.y != 10)
            {
                numberTest -= 1;
                Position(false);
            }
        }
        
        for(int i = 0; i < images.Count; i++)
        {
            if(images[i].transform.localPosition.y == 10)
            {
                for (int j = 0; j < things.Count; j++)
                {
                    things[j].SetActive(false);
                }
                things[i].SetActive(true);
            }
            

            if (images[i].transform.localPosition.y >= 210 || images[i].transform.localPosition.y <= -190)
            {
                images[i].enabled = false;
                //Debug.Log(images[i] + " y-pos = " + images[i].transform.localPosition.y + " enabled = " + images[i].enabled);
            }
            else
            {
                images[i].enabled = true;
                //Debug.Log(images[i] + " y-pos = " + images[i].transform.localPosition.y + " enabled = " + images[i].enabled);
            }
        }
        //StartCoroutine(Timer(5));
    }

    private void Position(bool up)
    {
        switch (up)
        {
            case true:
                for (int i = 0; i < images.Count; i++)
                {
                    yPos = images[i].transform.localPosition.y;
                    yPos += diffrence;

                    images[i].transform.localPosition = new Vector2(xPos, yPos);
                }
                break;
            case false:
                for (int i = images.Count - 1; i > -1; i--)
                {
                    yPos = images[i].transform.localPosition.y;
                    yPos -= diffrence;

                    images[i].transform.localPosition = new Vector2(xPos, yPos);
                }
                break;
        }
    }

    IEnumerator Timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
