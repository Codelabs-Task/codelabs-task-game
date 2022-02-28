using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text score;
    [SerializeField] private Text score2;

    private float _time = 0f;
    public static GameManager _intance;
    
    void Awake()
    {
        if(_intance != null && _intance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _intance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        score.text = "Score : " + Mathf.Round(_time / 2).ToString();
        score2.text = "Score : " + Mathf.Round(_time / 2).ToString();
    }
    public void showGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
