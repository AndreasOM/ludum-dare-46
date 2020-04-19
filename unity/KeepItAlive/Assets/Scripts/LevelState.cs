using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public enum State
    {
        None,
        Intro,
        Playing,
        Failure,
        Success,
    }

    public State state = State.None;
    public GameObject level;
    public float pathSpeed = 1.0f;    // distance along path per second
    public float pathDistance = 0.0f;
    public float balloonSpeed = 1.0f;
    public uint maxHealth = 1000;
    public uint currentHealth = 1000;
    public bool isGameRunning = false;
    public float inputDelay = 3.0f;

    public UIScreenController uiScreenController;
    private bool _wasGameRunning = false;
    private bool _waitingForInput = false;
    public float _inputWaitTime = 0.0f;
    void Start()
    {
        _wasGameRunning = !isGameRunning;    // enforce change update on update
    }

    void waitForInput()
    {
        _waitingForInput = true;
        _inputWaitTime = inputDelay;
        isGameRunning = false;
        _wasGameRunning = !isGameRunning;  // enforce change update on update
    }
    void gotoState(State state)
    {
        if (state == this.state)
        {
            return;
        }
        switch (state)
        {
            case State.Intro:
                {
                    uiScreenController.showIntro();
                    waitForInput();
                }
                break;
            case State.Playing:
                {
                    currentHealth = maxHealth;
                    pathDistance = 0.0f;
                    isGameRunning = true;
                    _waitingForInput = false;
                    uiScreenController.hide();
                    gameObject.BroadcastMessage("StartGame");
                }
                break;
            case State.Failure:
                {
                    uiScreenController.showFailure();
                    waitForInput();
                }
                break;
            case State.Success:
                {
                    uiScreenController.showSuccess();
                    waitForInput();
                }
                break;
        }

        this.state = state;
    }
    void Update()
    {
        if (state == State.None)
        {
            gotoState(State.Intro);
        }
        if (_waitingForInput)
        {
            if (_inputWaitTime >= 0.0f)
            {
                _inputWaitTime -= Time.unscaledDeltaTime;
            }
            else if (Input.anyKey)
            {
                switch (state)
                {
                    case State.Intro:
                        gotoState( State.Playing );
                        break;
                    case State.Failure:
                    case State.Success:
                        gotoState( State.Intro );
                        break;
                }
            }
        }
        if (_wasGameRunning != isGameRunning)
        {
            if (isGameRunning)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }

            _wasGameRunning = isGameRunning;
        }

        if (isGameRunning)
        {
            if (currentHealth <= 0)
            {
                gotoState( State.Failure );
            }
            pathDistance += Time.deltaTime * pathSpeed;
        }
    }

    public float getHealthPercentage()
    {
        return Mathf.Clamp01((float)currentHealth / maxHealth);
    }

    public uint onBalloonDamage(uint damage)
    {
        currentHealth = (uint)Mathf.Clamp((int)currentHealth - damage, 0, maxHealth);

        return currentHealth;
    }

    public void onBalloonReachedEnd()
    {
        gotoState( State.Success );
    }
}
