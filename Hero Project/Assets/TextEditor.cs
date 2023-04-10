using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{
    public static int numOfPlanes;
    public static int numOfBullets;
    public static int crashes;
    public static bool isUsingMouse;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        numOfPlanes = 0;
        numOfBullets = 0;
        crashes = 0;
        isUsingMouse = true;
    }

    // Update is called once per frame

    void Update()
    {
        text.text = "Number of Planes: " + numOfPlanes + "\nnumber of Bullets: " + numOfBullets + "\nNumber of Crashes: " + crashes + "\n";
        if(isUsingMouse)
            text.text += "Using Mouse";
        else
            text.text += "Using Keyboard";
    }
}
