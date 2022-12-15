using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Garbage : Interactable
{
    public UnityEvent interactAction;

    protected override void Interact()
    {
        interactAction.Invoke();
    }
}
