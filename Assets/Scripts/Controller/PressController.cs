using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressController : MonoBehaviour
{
    public Sprite spriteOn;
    public Sprite spriteOff;

    public UnityEvent onPress;
    public UnityEvent onReleased;

    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = spriteOff;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController _))
        {
            onPress.Invoke();
            _renderer.sprite = spriteOn;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController _))
        {
            onReleased.Invoke();
            _renderer.sprite = spriteOff;
        }
    }

}
