using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StreetLampController : MonoBehaviour
{
    public bool isOn = true;

    [SerializeField] private LightController _lightController;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite _spriteOn;
    [SerializeField] private Sprite _spriteOff;

    private float _timer = 0f;
    private Coroutine _currentCoroutine = null;

    public void Toggle(bool state)
    {
        isOn = state;
        _lightController.Toggle(isOn);
        _renderer.sprite = isOn ? _spriteOn : _spriteOff;
        if (!state && _currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator Flicker()
    {
        float intensity = _lightController.controlledLight.intensity;
        _lightController.controlledLight.enabled = false;
        yield return new WaitForSeconds(0.05f);
        _lightController.controlledLight.enabled = true;
        yield return new WaitForSeconds(0.05f);
        _lightController.controlledLight.enabled = false;
        yield return new WaitForSeconds(0.05f);
        _lightController.controlledLight.enabled = true;
    }

    public void Update()
    {
        if (!isOn)
        {
            return;
        }
        if (_timer <= 0f)
        {
            _timer = Random.Range(6f, 10f);
            _currentCoroutine = StartCoroutine(Flicker());
        }

        _timer -= Time.deltaTime;
    }
}
