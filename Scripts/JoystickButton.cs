using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public bool pressedButton;
    public void OnPointerDown(PointerEventData eventData)
    {
        pressedButton = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {       
        pressedButton = false;
    }
}
