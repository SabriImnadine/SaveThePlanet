using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [Header("Références")]
    public RectTransform pointer;          
    public Transform target;                

    private void Update()
    {
        if (pointer == null || target == null) return;

       
        Vector3 fromPosition = Camera.main.transform.position;
        Vector3 toPosition = target.position;

    
        fromPosition.z = 0f;
        toPosition.z = 0f;
        Vector3 direction = (toPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pointer.localEulerAngles = new Vector3(0, 0, angle);
    }
}