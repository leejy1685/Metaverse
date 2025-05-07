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
        //필요한 매니저 가져오기
        mapManager = MapManager.instance;
        uiManager = UIManager.instance;
        soundManager = SoundManager.instance;  

        //시작 화면
        uiManager.ChangeState(UIState.Home);

        //점프게임 초기 상태
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

    //점프 게임 장애물 생성 코루틴
    IEnumerator createArrow() 
    {
        while (true)
        {
            Instantiate(Obstacle);
            yield return new WaitForSeconds(1.5f);
        }
    }

    //점프 게임 점수 추가
    public void addJumpGamePoint()  
    {
        jumpGameScore++;
        //UI갱신
        uiManager.ChangeScore(jumpGameScore);
    }


    public void JumpGameOver()
    {
        //최고 점수 연산
        int bestScore = PlayerPrefs.GetInt(jumpGameBestScore);
        if (bestScore < jumpGameScore)
        {
            bestScore = jumpGameScore;
        }
        PlayerPrefs.SetInt(jumpGameBestScore, bestScore);

        //게임 종료 상태
        JumpGamePlayed = false;
        //코루틴 정지
        StopAllCoroutines();
        //레버 위치 원래대로
        jumpGameLever.LeftLever();

        //UI
        uiManager.ChangeGamePanel();
        uiManager.ChangeState(UIState.JumpGameOver);

        //Sound
        soundManager.ChangeBackGroundMusic(soundManager.stdBGMClip);
    }

    //초기 게임 시작
    public void StartGame()
    {
        uiManager.ChangeState(UIState.Game);
    }

    //컬러 커스텀 UI
    public void ColorCustumStart()
    {
        uiManager.ChangeState(UIState.ColorCustom);
    }

}
