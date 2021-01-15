using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text textScore;
    [Header("分數")]
    public int score;
    [Header("得分")]
    public int scoreHit = 5;
    [Header("玻璃音效")]
    public AudioClip soundGlass;

    private AudioSource aud;
    
    

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="酒瓶")
        {
            AddScore();
        }

        if (other.transform.root.name == "player")
        {
            scoreHit = 10;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "player")
        {
            scoreHit = 5;
        }
    }


    private void AddScore()
    {
        score += scoreHit;
        textScore.text = "得分：" + score;
        aud.PlayOneShot(soundGlass);
    }
}
