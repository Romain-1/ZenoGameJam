using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgLightController : MonoBehaviour
{
    private Animator _animator;
    public ThongController thong;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        _animator.Play("Update");
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
