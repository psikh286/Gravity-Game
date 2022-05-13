using System.Collections;
using System;
using TarodevController;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O) && CanSwitchGravity)
		{
			GravitySwitched?.Invoke(90);
			StartCoroutine(ReturnCamera(90));
		}

		if (Input.GetKeyDown(KeyCode.P) && CanSwitchGravity)
		{
			GravitySwitched?.Invoke(-90);
			StartCoroutine(ReturnCamera(-90));
		}
	}

	private void LateUpdate()
	{
		transform.position = _target.position + _offset;
	}

	#region ROTATING
	public static bool CanSwitchGravity = true;
	public Action<int> GravitySwitched;

	[SerializeField] private PlayerController _controller;
	[SerializeField] private float _speed;
	[SerializeField] private AnimationCurve _curve;
	private Vector3 _desiredRotation = Vector3.zero, _lastRotation = Vector3.zero;
	private float _current;

	private IEnumerator ReturnCamera(int direction)
	{
		CanSwitchGravity = false;

		Vector3 oldOffset = _offset;
		if (direction != 90)
		{			
			_offset.x = oldOffset.y;
			_offset.y = oldOffset.x;			
		}
		else
		{
			_offset.x = -oldOffset.y;
			_offset.y = oldOffset.x;
		}
		Vector3 newOffset = _offset;


		_lastRotation = transform.eulerAngles;
		transform.eulerAngles = Vector3.forward * direction;

		_current = 0;
		_desiredRotation = _lastRotation;
		_lastRotation = transform.eulerAngles;		

		while (true)
		{
			if (_current != 1)
			{
				_current = Mathf.MoveTowards(_current, 1, _speed * Time.deltaTime);
				float speed = _curve.Evaluate(_current);
				transform.rotation = Quaternion.Lerp(Quaternion.Euler(_lastRotation), Quaternion.Euler(_desiredRotation), speed);
				_offset = Vector3.Lerp(newOffset, oldOffset, speed);
			}
			else
			{
				CanSwitchGravity = true;
				StopAllCoroutines();		
			}
			yield return null;
		}
	}
	#endregion

	[Space]
	[Header("FOLLOW")]
	[SerializeField] private Vector3 _offset;
	[SerializeField] private Transform _target;

}
