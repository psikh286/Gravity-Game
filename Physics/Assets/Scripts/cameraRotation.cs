using System.Collections;
using TarodevController;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
	public static bool CanSwitchGravity = true;

	[SerializeField] private PlayerController _controller;
	[SerializeField] private float _speed;
	[SerializeField] private AnimationCurve _curve;	
	private Vector3 _desiredRotation = Vector3.zero, _lastRotation = Vector3.zero;
	private float _current;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O) && CanSwitchGravity)
		{
			CanSwitchGravity = false;
			_lastRotation = transform.eulerAngles;
			transform.eulerAngles = Vector3.forward * 90f;
			StartCoroutine(ReturnCamera());
		}

		if (Input.GetKeyDown(KeyCode.P) && CanSwitchGravity)
		{
			CanSwitchGravity = false;
			_lastRotation = transform.eulerAngles;
			transform.eulerAngles = Vector3.back * 90f;
			StartCoroutine(ReturnCamera());
		}	
	}

	private IEnumerator ReturnCamera()
	{
		yield return new WaitUntil(() => _controller.Grounded);
		_current = 0;
		_desiredRotation = _lastRotation;
		_lastRotation = transform.eulerAngles;
		while (true)
		{
			if (_current != 1)
			{
				_current = Mathf.MoveTowards(_current, 1, _speed * Time.deltaTime);
				transform.rotation = Quaternion.Lerp(Quaternion.Euler(_lastRotation), Quaternion.Euler(_desiredRotation), _curve.Evaluate(_current));
			}
			else
			{
				CanSwitchGravity = true;
				StopAllCoroutines();
			}
			yield return null;
		}
	}
}
