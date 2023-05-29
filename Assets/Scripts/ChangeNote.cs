using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNote : MonoBehaviour
{
    public GameObject image;
    public Texture2D theImage_1;
    public Texture2D theImage_2;
    public Texture2D theImage_3;
    public Texture2D theImage_4;
    public Texture2D theImage_5;
    public Texture2D theImage_6;
    public Texture2D theImage_7;

    public int[] index = new int[] { 1, 2, 3, 4, 5, 6, 7 };

    private void Start()
    {
        image = GameObject.Find("ImageObject");
    }

    public int DoChange()
    {
        Debug.Log("Start DoChange");

        UpsetRandom<int>.Shuffle(index);

        RawImage rawImage = GetComponent<RawImage>();
        if (rawImage == null)
        {
            Debug.LogError("RawImage component is missing.");
        }
        else
        {
            Debug.Log("RawImage component is get");
        }

        int check = index[0];

        switch (check)
        {
            case 1:
                rawImage.texture = theImage_1;
                break;
            case 2:
                rawImage.texture = theImage_2;
                break;
            case 3:
                rawImage.texture = theImage_3;
                break;
            case 4:
                rawImage.texture = theImage_4;
                break;
            case 5:
                rawImage.texture = theImage_5;
                break;
            case 6:
                rawImage.texture = theImage_6;
                break;
            case 7:
                rawImage.texture = theImage_7;
                break;
        }

        List<int> list = new List<int>(index);
        list.RemoveAt(0);
        index = list.ToArray();

        Debug.Log("End DoChange");
        return check;
    }

    public static void DoCheck(int check, int answer)
    {
        Debug.Log("Start DoCheck");

        bool result = false;
        Debug.Log("check 2: " + check);
        Debug.Log("answer 2: " + answer);
        switch (check){
            case 1:
                if (answer == 25)
                {
                    result = true;
                }
                break;
            case 2:
                if (answer == 27)
                {
                    result = true;
                }
                break;
            case 3:
                if (answer == 29)
                {
                    result = true;
                }
                break;
            case 4:
                if (answer == 30)
                {
                    result = true;
                }
                break;
            case 5:
                if (answer == 32)
                {
                    result = true;
                }
                break;
            case 6:
                if (answer == 34)
                {
                    result = true;
                }
                break;
            case 7:
                if (answer == 36)
                {
                    result = true;
                }
                break;
        }

        if (result == true)
        {
            ScoreBoard.Score += 1;
        }

        Debug.Log("End DoCheck");
    }

}
