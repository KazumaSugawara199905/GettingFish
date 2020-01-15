using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayerController : MonoBehaviour
{
    Rigidbody2D       _rb2;

    public GameObject player;
    Vector3           playerPos;
    Vector3           mousePosition;
    public float      MoveSpeed;
    bool              isMove;
    bool              canMove;
    float             startTime;

    // Start is called before the first frame update
    void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        if(player　== null)
            this.player = GameObject.Find("Player");
        isMove  = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("StageSelectPanel");
//        Debug.Log(gameObjects);
        if (gameObjects.Length == 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        if (Input.GetMouseButtonDown(0) && canMove)
        {
            mousePosition   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            //Debug.Log(mousePosition);
            playerPos = player.transform.position;
            //Debug.Log(playerPos);
            isMove    = true;
            startTime = Time.time;
        }
        if (isMove)
        {
            float move        = (Time.time - startTime) * MoveSpeed;
            float distance    = Vector3.Distance(playerPos, mousePosition);
            float fracJourney = move / distance;
            _rb2.MovePosition(Vector3.Lerp(playerPos, mousePosition, fracJourney));
        }
    }
}
