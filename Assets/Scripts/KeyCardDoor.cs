using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{
    [SerializeField] Color NeededKeyCard = Color.blue;

    [SerializeField] GameObject Player;

    [SerializeField] float openSpeed = 1f;
    [SerializeField] List<GameObject> doors = new List<GameObject>();
    [SerializeField] List<Vector3> doorTargets = new List<Vector3>();

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.HasColorCard(NeededKeyCard) & Vector3.Distance(Player.transform.position, transform.position) <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var doorTarget in doors.Zip(doorTargets, Tuple.Create))
            {
                GameObject door = doorTarget.Item1;
                Vector3 target = doorTarget.Item2;
                StartCoroutine(OpenDoorCoroutine(doorTarget.Item1, doorTarget.Item2));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    IEnumerator OpenDoorCoroutine(GameObject doorObject, Vector3 targetPosition)
    {
        float t = 0f;
        while (t < 1f)
        {
            doorObject.transform.position = Vector3.Lerp(doorObject.transform.position, targetPosition, openSpeed * Time.deltaTime);
            t += openSpeed * Time.deltaTime;
            yield return null;
        }
    }
}