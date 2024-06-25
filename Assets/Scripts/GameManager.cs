using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] OperationMode operationScript;
    [SerializeField] MovementVR MovementC;
    public enum GameState
    {
        PreOperation,
        MovementRoom,
        Operation
    }

    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.PreOperation);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        switch (CurrentState)
        {
            case GameState.MovementRoom:
                break;
            case GameState.Operation:
                operationScript.enabled = true;
                MovementC.enabled = false;
                break;
            case GameState.PreOperation:
                break;

        }
    }




   
}

