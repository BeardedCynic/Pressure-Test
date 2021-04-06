using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject AgentSpawner;
    [SerializeField] GameObject ChamberDoor;
    [SerializeField] GameObject MiniGames;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NavAgent")
        {
            MiniGames.SetActive(true);
            ChamberDoor.SetActive(true);

        }

    }
}