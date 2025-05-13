using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask viewLayer;
    [SerializeField] LayerMask characterLayer;
     [SerializeField] LayerMask tpLayer;

    public static Layers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask CharacterLayer {
        get => characterLayer;
    }

    public LayerMask SolidLayer {
        get => solidObjectsLayer;
    }

     public LayerMask ViewLayer {
        get => viewLayer;
    }

    public LayerMask InteractableLayer {
        get => interactableLayer;
    }

    public LayerMask TpLayer {
     get =>  tpLayer;  
    }

     public LayerMask TriggerLayer {
     get =>  viewLayer | tpLayer;  
    }
}
