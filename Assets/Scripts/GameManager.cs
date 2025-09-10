using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public int score { get; private set; } = 0;
	[SerializeField] private Player player;
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private GameObject playButton;
	[SerializeField] private GameObject gameOver;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;

		Pause();
	}
	public void Play()
	{
		score = 0;
		scoreText.text = score.ToString();

		playButton.SetActive(false);
		gameOver.SetActive(false);

		Time.timeScale = 1f;
		player.enabled = true;

		Pipes[] pipes = FindObjectsOfType<Pipes>();

		for (int i = 0; i < pipes.Length; i++)
		{
			Destroy(pipes[i].gameObject);
		}
	}
	public void GameOver()
	{
		gameOver.SetActive(true);
		playButton.SetActive(true);

		Pause();
	}
	public void Pause()
	{
		Time.timeScale = 0f;
		player.enabled = false;
	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
