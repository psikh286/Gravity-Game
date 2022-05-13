using TarodevController;
using UnityEngine;

public class gravityChange : MonoBehaviour
{
	[SerializeField] private PlayerController _controller;
	[SerializeField] private TrailRenderer _trail;
	[SerializeField] private GameObject _particles;
	[SerializeField] private cameraRotation _camera;

	private void Start()
	{
		_camera.GravitySwitched += SwitchGravity;
	}

	private void SwitchGravity(int direction)
	{
		if (direction != 90)
		{
			_particles.SetActive(false);
			transform.eulerAngles += Vector3.back * 90f;

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(t.y, -t.x, 0f);

			_trail.Clear();
			_particles.SetActive(true);
		}
		else
		{
			_particles.SetActive(false);
			transform.eulerAngles += Vector3.forward * 90f;

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(-t.y, t.x, 0f);

			_trail.Clear();
			_particles.SetActive(true);
		}
		
	}
}
