    using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] public GameObject prefab;
	[SerializeField] public float spawnRate = 1f;
	[SerializeField] public float minHeight = -1f;
	[SerializeField] public float maxHeight = 1f;

	private void OnEnable()
	{
		InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
	}

	private void OnDisable()
	{
		CancelInvoke(nameof(Spawn));
	}

	private void Spawn()
	{
		GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
		pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
	}
}
