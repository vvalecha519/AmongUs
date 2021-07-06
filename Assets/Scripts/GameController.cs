using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    int imposters;
    int crew;

    enum GameState
    {
        Lobby,
        Explore,
        Discuss,
        Vote,
        VoteResultScene
    }



    // Start is called before the first frame update
    void Start() {
        imposters = 0;
        crew = 0;

    }

    // Update is called once per frame
    void Update() {
    }

    void killCrew() {
        crew--;
        if (imposters >= crew) {
            endGame();
        }
    }

    void endGame() {}
    void startRound() {}
}


