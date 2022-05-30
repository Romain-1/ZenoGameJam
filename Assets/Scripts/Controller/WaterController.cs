using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private List<InsectController> _insects = new List<InsectController>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out InsectController insect))
        {
            _insects.Add(insect);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out InsectController insect))
        {
            _insects.Remove(insect);
        }
    }

    void Update()
    {
        foreach(var insect in _insects)
        {
            if (!insect.IsMoving && insect.staticSince > 1f)
            {
                insect.Drown();
            }
        }

        _insects.RemoveAll(insect => (!insect.IsMoving && insect.staticSince > 1f));
    }
}
