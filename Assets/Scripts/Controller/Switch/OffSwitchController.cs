using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OffSwitchController : MonoBehaviour
{
    [SerializeField] private SwitchController _parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            _parent.OffPressed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _parent.OutOfButton();
    }
}
