using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
	[SerializeField] int index;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
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

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}
}
