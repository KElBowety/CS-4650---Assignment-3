using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayState : IState
{
    bool active;
    GameObject obj, player;
    Canvas canvas;

    public GameplayState()
    {
        active = false;
        obj = GameObject.Find("BulletPhysicsWorld");
        canvas = Object.FindObjectOfType<Canvas>();
        player = GameObject.Find("Player");
    }
    public void EnterState()
    {
        active = true;
        canvas.GetComponentsInChildren<Text>()[0].text = "Pause";
        canvas.GetComponentsInChildren<Text>()[1].text = "";
        player.GetComponent<ControllerScirpt>().pause = false;
        obj.SetActive(true);
    }

    public void ExitState()
    {
        active = false;
    }

    public bool GetActive()
    {
        return active;
    }
}
