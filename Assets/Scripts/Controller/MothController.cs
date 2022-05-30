using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : InsectController
{
    public float minDistance = 0.1f;

    private List<LightController> _followings = new List<LightController>();
    // private LightController _following = null;
    private float _goingBackTimer = 0f;
    private Vector2 _goingBackTarget;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<LightController>(out LightController l))
        {
            // if (_following == null || l.priority > _following.priority)
            //     _following = l;
            l.OnSwitchOff(() =>
            {
                _followings.Remove(l);
            });
            _followings.Add(l);
            _followings.Sort((x, y) => y.priority.CompareTo(x.priority));
        }
    }

    public override void Die()
    {
        level.MothDied();
        base.Die();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (LevelScene.gameStopped) return;

        base.Update();
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

        if (_goingBackTimer > 0f)
        {
            MoveTowardsTarget(_goingBackTarget);
            _goingBackTimer -= Time.deltaTime;
        }
        else if (distance > minDistance)
        {
            MoveTowardsTarget(_followings[0].transform.position);
        }
        else
        {
            _goingBackTimer = UnityEngine.Random.Range(0.02f, 0.1f);
            float radius = UnityEngine.Random.Range(5f, 10f);
            float angle = _angleTowards - 180 + UnityEngine.Random.Range(-90f, 90f);
            _goingBackTarget = new Vector2(
                radius * Mathf.Sin(Mathf.PI * 2 * angle / 360f) + _followings[0].transform.position.x,
                radius * Mathf.Cos(Mathf.PI * 2 * angle / 360f) + _followings[0].transform.position.y
            );
        }
    }
}
