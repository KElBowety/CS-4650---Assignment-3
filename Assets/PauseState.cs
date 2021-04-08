using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseState : IState
{
    bool active;
    GameObject obj, player;
    Canvas canvas;

    public PauseState()
    {
        active = false;
        obj = GameObject.Find("BulletPhysicsWorld");
        canvas = Object.FindObjectOfType<Canvas>();
        player = GameObject.Find("Player");
    }
    public void EnterState()
    {
        active = true;
        canvas.GetComponentsInChildren<Text>()[0].text = "Resume";
        canvas.GetComponentsInChildren<Text>()[1].text = "Paused";
        player.GetComponent<ControllerScirpt>().pause = true;
        obj.SetActive(false);
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
