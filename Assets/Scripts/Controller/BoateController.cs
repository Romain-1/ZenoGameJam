using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoateController : MonoBehaviour
{
    public PlayerController player;
    public AnimationCurve fadeCurve;
    public float fadeDuration = 1f;
    public SpriteRenderer _renderer;

    private float _timerFade = 0f;
    private bool _isInBoate = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController p))
        {
            _isInBoate = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController p))
        {
            _isInBoate = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _timerFade = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldFade = _isInBoate;

        _timerFade = Mathf.Clamp01(_timerFade + Time.deltaTime * (shouldFade ? 1 : -1) / fadeDuration);
        Color c = _renderer.color;

        _renderer.color = new Color(c.r, c.g, c.b, fadeCurve.Evaluate(1 - _timerFade));
    }
}
