using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static GameManager instance;
    //∏ 
    MapManager mapManager;
    //UI
    UIManager uiManager;


    //¡°«¡ ∞‘¿”
    [SerializeField] LeverController jumpGameLever;
    public bool jumpGameStarted { get; set; }
    public bool JumpGamePlayed {  get; set; }
    [SerializeField] GameObject Obstacle;
    private int jumpGameScore = 0;
    public int JumpGameScore { get { return jumpGameScore; } }

    private const string jumpGameBestScore = "JumpGame";
    public string JumpGameBestScore { get {return jumpGameBestScore;} }



    //«√∑π¿ÃæÓ
    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        //ΩÃ±€≈Ê «“¥Á
        instance = this;
    }

    private void Start()
    {
        mapManager = MapManager.instance;
        uiManager = UIManager.instance;

        uiManager.ChangeState(UIState.Home);

        jumpGameStarted = false;
        JumpGamePlayed = false;
    }

    public void JumpGameStart()
    {
        //∞‘¿” º≥¡§
        jumpGameStarted = true;
        StartCoroutine(createArrow());
        jumpGameScore = 0;

        //UI º≥¡§
        uiManager.ChangeScore(jumpGameScore);
        uiManager.ChangeState(UIState.JumpGame);
    }

    IEnumerator createArrow()
    {
        while (true)
        {
            Instantiate(Obstacle);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void JumpGameOver()
    {
        int bestScore = PlayerPrefs.GetInt(jumpGameBestScore);
        if (bestScore < jumpGameScore)
        {
            bestScore = jumpGameScore;
        }
        PlayerPrefs.SetInt(jumpGameBestScore, bestScore);

        JumpGamePlayed = false;
        StopAllCoroutines();
        jumpGameLever.LeftLever();

        //UI
        uiManager.ChangeGameOverPanel();
        uiManager.ChangeState(UIState.JumpGameOver);
    }

    public void StartGame()
    {
        uiManager.ChangeState(UIState.Game);
    }
    public void addJumpGamePoint()
    {
        jumpGameScore++;
        //UI∞ªΩ≈
        uiManager.ChangeScore(jumpGameScore);
    }

}
