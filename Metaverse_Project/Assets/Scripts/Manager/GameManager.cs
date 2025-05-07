using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    //맵
    MapManager mapManager;
    //UI
    UIManager uiManager;
    //Sound
    SoundManager soundManager;


    //점프 게임
    [SerializeField] LeverController jumpGameLever;
    public bool jumpGameStarted { get; set; }
    public bool JumpGamePlayed {  get; set; }
    [SerializeField] GameObject Obstacle;
    private int jumpGameScore = 0;
    public int JumpGameScore { get { return jumpGameScore; } }

    private const string jumpGameBestScore = "JumpGame";
    public string JumpGameBestScore { get {return jumpGameBestScore;} }



    //플레이어
    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        //싱글톤 할당
        instance = this;
    }

    private void Start()
    {
        mapManager = MapManager.instance;
        uiManager = UIManager.instance;
        soundManager = SoundManager.instance;  

        uiManager.ChangeState(UIState.Home);

        jumpGameStarted = false;
        JumpGamePlayed = false;
    }

    public void JumpGameStart()
    {
        //게임 설정
        jumpGameStarted = true;
        StartCoroutine(createArrow());
        jumpGameScore = 0;

        //UI 설정
        uiManager.ChangeScore(jumpGameScore);
        uiManager.ChangeState(UIState.JumpGame);

        //사운드 설정
        soundManager.ChangeBackGroundMusic(soundManager.gameBGMClip);
    }

    IEnumerator createArrow()
    {
        while (true)
        {
            Instantiate(Obstacle);
            yield return new WaitForSeconds(1.5f);
        }
    }
    public void addJumpGamePoint()
    {
        jumpGameScore++;
        //UI갱신
        uiManager.ChangeScore(jumpGameScore);
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
        uiManager.ChangeGamePanel();
        uiManager.ChangeState(UIState.JumpGameOver);

        //Sound
        soundManager.ChangeBackGroundMusic(soundManager.stdBGMClip);
    }

    public void StartGame()
    {
        uiManager.ChangeState(UIState.Game);
    }

    public void ColorCustumStart()
    {
        uiManager.ChangeState(UIState.ColorCustom);
    }

}
