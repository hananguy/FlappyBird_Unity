using UnityEngine;

public class Pipes : MonoBehaviour
{
	[SerializeField] public float speed = 5f;
	[SerializeField] private float leftEdge;

	public void Start()
	{
		leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
	}

	public void Update()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;

		if(transform.position.x < leftEdge )
		{
			Destroy(gameObject);
		}
	}
}
