using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 0.1f;

    protected float _angleTowards = 0;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected void SetIsMoving(bool state)
    {
        _animator.SetBool("IsMoving", state);
    }

    protected void UpdateRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _angleTowards - 90), rotationSpeed);
    }

    protected void MoveTowardsTarget(Vector2 target)
    {
        float angleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        _angleTowards = (180 / Mathf.PI) * angleRad;
        transform.position += speed * Time.deltaTime * transform.up;
    }
}
