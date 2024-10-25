using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorOpenSwitcher : MonoBehaviour
{
    [SerializeField] private float currentDegrees = 0f;
    [SerializeField] private float doorRotateSpeed = 1f;
    [SerializeField] private Transform doorPivot;
    private float currentVelocity;

    void Update()
    {
        float newAngle = Mathf.SmoothDampAngle(doorPivot.localRotation.eulerAngles.z, currentDegrees, ref currentVelocity, doorRotateSpeed);
        doorPivot.localRotation = Quaternion.Euler(doorPivot.localRotation.eulerAngles.x, doorPivot.localRotation.eulerAngles.y, newAngle);
    }
}
