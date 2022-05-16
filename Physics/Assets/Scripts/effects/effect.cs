using TarodevController;
using UnityEngine;

public class effect : MonoBehaviour
{
	[SerializeField] private string _effect;
	[SerializeField] private float _value;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.gameObject.GetComponent<PlayerController>().ChangeVars(_effect, _value);
		}
	}
}
