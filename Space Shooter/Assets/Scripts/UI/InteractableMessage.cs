using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMessage : MonoBehaviour
{
    static Text msgText;
    public Text text;

    private void Awake()
    {
        msgText = text;
        HideText();
    }

    public static void ShowText(string message)
    {
        msgText.text = "Press E to " + message;
    }

    public static void HideText()
    {
        msgText.text = "";
    }
}
