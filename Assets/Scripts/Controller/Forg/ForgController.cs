using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgController : MonoBehaviour
{
    public float animOffsetSeconds = 1f;
    public ThongController _thong;
    public LevelScene level;

    private Animator _animator;

    IEnumerator WaitBeforeAnimation()
    {
        yield return new WaitForSeconds(animOffsetSeconds);
        _animator.Play("Update");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(WaitBeforeAnimation());
    }

    void Eat()
    {
        Transform tr = _thong.transform;
        for (int i = tr.childCount - 1; i >= 0; --i)
        {
            if (tr.GetChild(i).gameObject.TryGetComponent(out InsectController p))
                p.Die();
        }
    }
}
