using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 0.1f;
    public bool IsMoving {private set; get;}
    public LevelScene level;

    protected float _angleTowards = 0;
    private Animator _animator;
    public bool IsKo {private set; get; } = false;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void KnockOut()
    {
        IsKo = true;
    }

    public void Drown()
    {
        KnockOut();
        _animator.SetBool("IsDrowning", true);
    }

    public virtual void Die()
    {
        print("Le game object est destroy la");
        GameObject.Destroy(gameObject);
    }

    protected void SetIsMoving(bool state)
    {
        IsMoving = state;
        _animator.SetBool("IsMoving", state);
    }

    protected void UpdateRotation()
    {
        if (IsKo) return;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _angleTowards - 90), rotationSpeed);
    }

    protected void MoveTowardsTarget(Vector2 target)
    {
        if (IsKo) return;

        float angleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        _angleTowards = (180 / Mathf.PI) * angleRad;
        transform.position += speed * Time.deltaTime * transform.up;
    }
}
