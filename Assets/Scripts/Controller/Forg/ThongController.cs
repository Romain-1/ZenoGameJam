using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThongController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out InsectController insect))
        {
            insect.KnockOut();
            insect.transform.parent = transform;
        }
    }
}
