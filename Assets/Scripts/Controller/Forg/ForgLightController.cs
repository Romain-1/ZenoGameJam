using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgLightController : MonoBehaviour
{
    private Animator _animator;
    public ThongController thong;

    private List<Light> _lights = new List<Light>();

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Light l))
        {
            _lights.Add(l);
            _animator.Play("Update");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Light l))
        {
            _lights.Remove(l);
        }
    }

    private void Update()
    {
        _animator.SetBool("IsTrigger", _lights.Count > 0);
    }

    void Eat()
    {
        Transform tr = thong.transform;
        for (int i = tr.childCount - 1; i >= 0; --i)
        {
            if (tr.GetChild(i).gameObject.TryGetComponent(out InsectController p))
                p.Die();
        }
    }
}
