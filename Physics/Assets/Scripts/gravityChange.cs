using TarodevController;
using UnityEngine;

public class gravityChange : MonoBehaviour
{
	[SerializeField] private PlayerController _controller;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O) && cameraRotation.CanSwitchGravity)
		{
			transform.eulerAngles = Vector3.forward * 90f;

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(-t.y, t.x, 0f);
		}

		if (Input.GetKeyDown(KeyCode.P) && cameraRotation.CanSwitchGravity)
		{
			transform.eulerAngles = Vector3.back * 90f;

			var t = _controller.transform.position;
			_controller.transform.position = new Vector3(t.y, -t.x, 0f);
		}
	}
}
