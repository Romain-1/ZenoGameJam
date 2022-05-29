using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : InsectController
{
    public float minDistance = 0.1f;

    private List<LightController> _followings = new List<LightController>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<LightController>(out LightController l))
        {
            l.OnSwitchOff(() =>
            {
                _followings.Remove(l);
            });
            _followings.Add(l);
            _followings.Sort((x, y) => y.priority.CompareTo(x.priority));
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SetIsMoving(_followings.Count > 0);
        if (_followings.Count > 0)
        {
            UpdateRotation();
            UpdateFollow();
        }
    }


    private void UpdateFollow()
    {
        float distance = Vector2.Distance(_followings[0].transform.position, transform.position);

        if (distance > minDistance)
        {
            MoveTowardsTarget(_followings[0].transform.position);
        }
    }
}
