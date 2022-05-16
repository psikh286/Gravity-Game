using System.Collections;
using System;
using TarodevController;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
	public static bool CanSwitchGravity = true;
	public Action<int> GravitySwitched;

	[SerializeField] private float _speed;
	[SerializeField] private AnimationCurve _curve;
	[SerializeField] private PlayerController _controller;
	private Vector3 _lastRotation = Vector3.zero;
	private float _current;
	private bool _canSwitchGravity = true;

	[Space]
	[Header("FOLLOW")]
	[SerializeField] private Vector3 _offset;
	private Transform _target;

	private void Awake()
	{
		_target = _controller.transform;
		CanSwitchGravity = false;
	}

	private void Update()
	{
		if (CanSwitchGravity)
		{
			if (Input.GetKeyDown(KeyCode.O) && _canSwitchGravity)
			{
				GravitySwitched?.Invoke(90);
				StartCoroutine(ReturnCamera(90));
			}

			if (Input.GetKeyDown(KeyCode.P) && _canSwitchGravity)
			{
				GravitySwitched?.Invoke(-90);
				StartCoroutine(ReturnCamera(-90));
			}
		}
	}

	private void LateUpdate()
	{
		transform.position = _target.position + _offset;
	}	

	public IEnumerator ReturnCamera(int direction)
	{
		CanSwitchGravity = false;
		_canSwitchGravity = false;

		Vector3 oldOffset = _offset;
		if (direction != 90)
		{			
			_offset.x = oldOffset.y;
			_offset.y = oldOffset.x;			
		}
		else if(direction == 90)
		{
			_offset.x = -oldOffset.y;
			_offset.y = oldOffset.x;
		}
		
		Vector3 newOffset = _offset;
		transform.eulerAngles = Vector3.forward * direction;

	
		_current = 0;
		_lastRotation = transform.eulerAngles;		

		while (true)
		{
			if (_current != 1)
			{
				_current = Mathf.MoveTowards(_current, 1, _speed * Time.deltaTime);
				float speed = _curve.Evaluate(_current);
				transform.rotation = Quaternion.Lerp(Quaternion.Euler(_lastRotation), Quaternion.Euler(Vector3.zero), speed);
				_offset = Vector3.Lerp(newOffset, oldOffset, speed);
			}
			else
			{
				_canSwitchGravity = true;
				StopAllCoroutines();
			}
			yield return null;
		}
	}	
}
