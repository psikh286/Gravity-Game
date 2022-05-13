using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

	private void Update()
	{
        transform.position = target.position + offset;
	}
}

