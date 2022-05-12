using TarodevController;
using UnityEngine;

public class gravityChange : MonoBehaviour
{
	[SerializeField] private PlayerController _controller;
	[SerializeField] private TrailRenderer _trail;
	[SerializeField] private GameObject _particles;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O) && cameraRotation.CanSwitchGravity)
		{
			_particles.SetActive(false);
			transform.eulerAngles += Vector3.forward * 90f;			

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(-t.y, t.x, 0f);
			
			_trail.Clear();
			_particles.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.P) && cameraRotation.CanSwitchGravity)
		{
			_particles.SetActive(false);
			transform.eulerAngles += Vector3.back * 90f;

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(t.y, -t.x, 0f);

			_trail.Clear();
			_particles.SetActive(true);
		}
	}
}
