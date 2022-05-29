using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InsectController
{
	public float distanceBeforeStop = 0.5f;

	[Serializable]
	public struct FireFlySprites
	{
		public Sprite[] legs;
		public Sprite[] antennae;
		public Sprite[] innerWings;
		public Sprite[] outerWings;
		public Sprite body;
	}

	public FireFlySprites onSprites;
	public FireFlySprites offSprites;

	public SpriteRenderer[] legs;
	public SpriteRenderer[] antennae;
	public SpriteRenderer[] innerWings;
	public SpriteRenderer[] outerWings;
	public SpriteRenderer body;

	[SerializeField] private LightController _lightController;

	private Vector2 _lastMousePos;
	public enum State
	{
		On, Off
	}

	public State state = State.Off;

	public void Start()
	{
		_lastMousePos = transform.position;
	}

	public void Update()
	{
		UpdateRotation();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwapState();
		}

		Vector2 target = _lastMousePos;

		if (Input.GetMouseButton(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		float distance = Vector2.Distance(transform.position, target);

		SetIsMoving(distance > distanceBeforeStop);
		if (distance > distanceBeforeStop)
		{
			MoveTowardsTarget(target);
			_lastMousePos = target;
		}
	}

	private void SwapState()
	{
		state = (state == State.Off) ? State.On : State.Off;

		_lightController.Toggle(state == State.On);
		FireFlySprites sprites = (state == State.Off) ? onSprites : offSprites;

		for (int i = 0; i < sprites.legs.Length; ++i) legs[i].sprite = sprites.legs[i];
		for (int i = 0; i < sprites.antennae.Length; ++i) antennae[i].sprite = sprites.antennae[i];
		for (int i = 0; i < sprites.innerWings.Length; ++i) innerWings[i].sprite = sprites.innerWings[i];
		for (int i = 0; i < sprites.outerWings.Length; ++i) outerWings[i].sprite = sprites.outerWings[i];
		body.sprite = sprites.body;
	}
}
