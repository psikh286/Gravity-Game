using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			cameraRotation.CanSwitchGravity = true;
		}		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			cameraRotation.CanSwitchGravity = true;
		}
	}
}
