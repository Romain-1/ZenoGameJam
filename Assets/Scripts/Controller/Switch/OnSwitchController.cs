using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OnSwitchController : MonoBehaviour
{
    [SerializeField] private SwitchController _parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            _parent.OnPressed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _parent.OutOfButton();
    }
}
