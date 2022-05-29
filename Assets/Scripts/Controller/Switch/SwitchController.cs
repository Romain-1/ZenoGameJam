using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public StreetLampController lamp;

    public Sprite spriteOn;
    public Sprite spriteOff;
    public LineRenderer line;
    public Color lineOnColor;
    public Color lineOffColor;

    private SpriteRenderer _renderer;

    private bool _stillOnSwitch = false;

    private void HandleSwitch(bool isOn)
    {
        _renderer.sprite = isOn ? spriteOn : spriteOff;
        lamp.Toggle(isOn);
        _stillOnSwitch = true;
        line.startColor = isOn ? lineOnColor : lineOffColor;
        line.endColor = line.startColor;
    }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        HandleSwitch(lamp.isOn);
        _stillOnSwitch = false;
    }

    public void OutOfButton()
    {
        _stillOnSwitch = false;
    }

    public void OnPressed()
    {
        HandleSwitch(true);
    }

    public void OffPressed()
    {
        HandleSwitch(false);
    }
}
