using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LightController : MonoBehaviour
{
    public int priority = 0;
    public float rangeIntensity = 1f;
    public float rangeZValue = 0.3f;

    public Light controlledLight;
    private CircleCollider2D _collider;
    private List<Action> _actions = new List<Action>();

    private float _baseIntensity;
    private float _baseZValue;
    private float _timer = 0f;

    void Awake()
    {
        controlledLight = GetComponent<Light>();
        _collider = GetComponent<CircleCollider2D>();
        _baseIntensity = controlledLight.intensity;
        _baseZValue = controlledLight.transform.position.z;
        _timer = Random.Range(0, 100);
    }

    public void OnSwitchOff(Action act)
    {
        _actions.Add(act);
    }

    public void Toggle(bool state)
    {
        controlledLight.enabled = state;
        _collider.enabled = state;

        if (state == false)
        {
            for (int i = 0; i < _actions.Count; ++i)
            {
                _actions[i]();
            }
            _actions.Clear();
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        controlledLight.intensity = Mathf.Sin(_timer) * rangeIntensity + _baseIntensity;
        Vector3 pos = controlledLight.transform.position;
        pos.z = -Mathf.Sin(_timer) * rangeZValue + _baseZValue;
        controlledLight.transform.position = pos;
    }
}
