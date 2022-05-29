using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public OffSwitchController offSwitch;
    public OnSwitchController onSwitch;
    public StreetLampController lamp;

    private bool _stillOnSwitch = false;

    private void HandleSwitch(bool isOn)
    {
        onSwitch._renderer.enabled = !isOn;
        offSwitch._renderer.enabled = isOn;
        lamp.Toggle(isOn);
        _stillOnSwitch = true;
    }

    private void Start()
    {
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
