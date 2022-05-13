using UnityEngine;


public class basicPlatform : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{			
			cameraRotation.CanSwitchGravity = true;
		}
	}
}
