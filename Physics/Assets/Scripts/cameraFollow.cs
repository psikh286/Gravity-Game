using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;
	[SerializeField] private cameraRotation _camera;

	private void Start()
	{
		_camera.GravitySwitched += SwitchGravity;
	}

	private void SwitchGravity(int direction)
	{
		float _currentOffsetX = _offset.x;
		float _currentOffsetY = _offset.y;

		_offset.x = _currentOffsetY;
		_offset.y = _currentOffsetX;


	}

	private void Update()
	{
        transform.position = _target.position + _offset;
	}
}

