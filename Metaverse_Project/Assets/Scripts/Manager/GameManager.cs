using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static GameManager instance;
    //∏ 
    MapManager mapManager;

    //¡°«¡ ∞‘¿”
    [SerializeField] LeverController jumpGameLever;
    public bool jumpGameStarted { get; set; }
    public bool JumpGamePlayed {  get; set; }
    [SerializeField] GameObject Obstacle;
    public int jumpGamePoint;


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
    }

    public void JumpGameStart()
    {
        jumpGameStarted = true;
        StartCoroutine(createArrow());
        jumpGamePoint = 0;
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
        JumpGamePlayed = false;
        StopAllCoroutines();
        jumpGameLever.LeftLever();
    }

    public void addJumpGamePoint()
    {
        jumpGamePoint++;
        Debug.Log(jumpGamePoint);
        
    }

}
