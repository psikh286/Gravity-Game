using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //public vars    
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

	private void Update()
	{
        transform.position = target.position + offset;
	}
}

