using UnityEngine.SceneManagement;
using UnityEngine;

public class travelTo : MonoBehaviour
{
	[SerializeField] private int index;
	[SerializeField] private string url;
	public void GOOOOOOO()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
	}

	public void QUIIIIIT()
	{
		Application.Quit();
	}

	public void LINK()
	{
		Application.OpenURL(url);
	}
}
