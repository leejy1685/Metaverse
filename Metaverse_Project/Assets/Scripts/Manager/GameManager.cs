using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static GameManager instance;

    //¡°«¡ ∞‘¿” ªÛ≈¬
    public bool jumpGameStarted { get; set; }
    public bool JumpGamePlayed {  get; set; }



    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        //ΩÃ±€≈Ê «“¥Á
        instance = this;
    }

}
