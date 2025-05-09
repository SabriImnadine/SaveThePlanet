using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;

    public static Layers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer {
        get => solidObjectsLayer;
    }

    public LayerMask InteractableLayer {
        get => interactableLayer;
    }
}
