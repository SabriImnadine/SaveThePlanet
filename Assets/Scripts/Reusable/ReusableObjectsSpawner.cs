using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReusableObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ResuableObjectPrefab;

    void Awake()
    {
        bool alreadyExists = FindFirstObjectByType<ReusableObjects>() != null;

        if (!alreadyExists)
        {
            Instantiate(ResuableObjectPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
