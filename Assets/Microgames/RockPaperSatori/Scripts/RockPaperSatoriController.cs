﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperSatoriController : MonoBehaviour
{
    [SerializeField]
    private float startDelay;

    [SerializeField]
    private RockPaperSatoriPlayer player;
    [SerializeField]
    private RockPaperSatoriOpponent opponent;

    private bool gameStarted;

    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    void Start()
    {
        gameStarted = false;
        Invoke("startGame", startDelay);
    }

    void startGame()
    {
        player.startGame();
        opponent.startGame();
        gameStarted = true;
    }

    public void makeMove(Move move)
    {
        //Decide if player won
        RockPaperSatoriPlayer.State playerState;
        if (move == opponent.getMove())
            playerState = RockPaperSatoriPlayer.State.Tie;
        else if (MathHelper.trueMod(((int)move - 1), 3) == (int)opponent.getMove())
            playerState = RockPaperSatoriPlayer.State.Victory;
        else
            playerState = RockPaperSatoriPlayer.State.Loss;

        //Set victory
        MicrogameController.instance.setVictory(playerState == RockPaperSatoriPlayer.State.Victory);
        player.throwHand(move, playerState);
        opponent.throwHand(playerState);
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }
    
    
}
