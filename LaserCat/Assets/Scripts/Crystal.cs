using System;
using DG.Tweening;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]
    protected GameObject glass;
    public bool isRotating = false;
    protected Vector3 center;
    [SerializeField]
    protected float speed;
    protected Vector2 oldPos;
    protected Vector2 swipeDelta;
    protected float xRotate;
    protected float yRotate;
    public float outlineWidth;
    protected float leap = 50;

    void Start()
    {
        center = Camera.main.WorldToScreenPoint(transform.position);
        transform.DOMoveY(transform.position.y + 2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if(isRotating)
        {
            RotateCrystal();
            glass.GetComponent<Outline>().OutlineWidth = outlineWidth;
        }
        else
        {
            glass.GetComponent<Outline>().OutlineWidth = 0;
        }
    }

    void RotateCrystal()
    {
        if (Input.GetMouseButton(0))
        {
            if (oldPos.x == 0 && oldPos.y == 0)
            {
                oldPos = (Vector2)Input.mousePosition;
            }

            swipeDelta = (Vector2)Input.mousePosition - oldPos;

            if (Math.Abs(swipeDelta.x) + Math.Abs(swipeDelta.y) > leap)
            {
                swipeDelta = new Vector2(0, 0);
            }

            xRotate = swipeDelta.x / Screen.currentResolution.width;
            yRotate = swipeDelta.y / Screen.currentResolution.height;

            if (Input.mousePosition.x > center.x && Input.mousePosition.y > center.y)
            {
                yRotate *= -1;
            }

            else if (Input.mousePosition.x < center.x && Input.mousePosition.y < center.y)
            {
                xRotate *= -1;
            }
            else if (Input.mousePosition.x > center.x && Input.mousePosition.y < center.y)
            {
                xRotate *= -1;
                yRotate *= -1;
            }

            oldPos = (Vector2)Input.mousePosition;
            //if (glass.transform.eulerAngles.y > blindZoneTo - blindSpotAngle && glass.transform.eulerAngles.y < blindZoneTo && xRotate + yRotate < 0) return;
            //else if (glass.transform.eulerAngles.y > blindZoneFrom && glass.transform.eulerAngles.y < blindZoneFrom + blindSpotAngle && xRotate + yRotate > 0) return;

            glass.transform.Rotate(0, speed * (xRotate + yRotate), 0);
        }
    }
}
