using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    public Image fill;
    public Text valTxt;
    public int currentValue;
    Vector3 mousePos;

    private void Update()
    {

    }
    public void OnHandleDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Converts the angle of the handle into degrees
        angle = (angle <= 0) ? (360 + angle) : angle;

        if (angle<=225 || angle >= 315) //clamps calculations within the sector's range
        {
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            handle.rotation = r;
            //Uses Quaternion to convert the current angle input into degrees and set the reference point to a direction in world space
            angle = ((angle >= 315) ? (angle - 360) : angle) +45;
            //Sets the angle back to the origin point if it leaves the upper bounds
            fill.fillAmount = 0.75f - (angle / 360f);
            //returns a float representing the current degree value of the reference point
            valTxt.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString();
            //Rounds to the nearest int and converts the value to be output in text
        }
        Debug.Log("Drag");
    }
}
