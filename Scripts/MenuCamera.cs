﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    public Transform shopWaypoint;
    private void Start()
    {
        startPosition = desiredPosition = transform.localPosition;
        startRotation = desiredRotation = transform.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, 0.1f);
        transform.localRotation = Quaternion.Lerp(transform.rotation, desiredRotation, 0.1f);

    }



    public void BackToMainMenu()
    {
        desiredPosition = startPosition;
        desiredRotation = startRotation;
    }
    public void MoveToShop()
    {
        desiredPosition = shopWaypoint.localPosition;
        desiredRotation = shopWaypoint.localRotation;
    }

}
