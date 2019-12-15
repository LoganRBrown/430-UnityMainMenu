using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void ClickDelegate();

[RequireComponent(typeof(Button), typeof(Image))]
public class BasicButton : MonoBehaviour, IPointerEnterHandler 
{
    ClickDelegate callBack;
    
    public Text textField;

    public void Init(string caption, Sprite image = null, ClickDelegate callBack = null)
    {
        textField.text = caption;
        this.callBack = callBack;
        GetComponent<Image>().sprite = image;
    }

    public void Clicked()
    {
        if (callBack != null) callBack();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Button>().Select();
    }
}
