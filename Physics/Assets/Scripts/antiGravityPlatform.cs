using UnityEngine;

public class antiGravityPlatform : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			cameraRotation.CanSwitchGravity = false;
		}
	}	
}