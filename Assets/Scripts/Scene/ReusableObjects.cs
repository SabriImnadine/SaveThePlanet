using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReusableObjects : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
