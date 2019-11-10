using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{

    public bool startHidden = false;

    public void Show()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        OnShow();
    }

    public void Hide()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    protected virtual void OnShow()
    {

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (startHidden)
            Hide();
    }

    protected virtual void Update()
    {

    }
}
