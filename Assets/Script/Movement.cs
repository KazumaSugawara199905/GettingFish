using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float             moveSpeed;
    public float             torqueCorfficient;
    public float             swayTime;
    Vector3                  moveVec;
    Rigidbody2D              _rb2;
    Collider2D               _col2;
    GameObject               player;
    Dictionary<int, Vector2> directionVer;
    float                    _fT;              //経過時間
    float                    direction;

    private void Start()
    {
        player    = GameObject.FindGameObjectWithTag("Player");
        moveVec.x = 0 - gameObject.transform.position.x;
        _rb2      = GetComponent<Rigidbody2D>();


        directionVer = new Dictionary<int, Vector2>()
        {
            {0,Vector2.down},
            {1,Vector2.up },
            {2,Vector2.zero }
        };

        //Sprite反転処理
        Vector3 scale        = transform.localScale;
        direction            = moveVec.x / Mathf.Abs(moveVec.x);
        scale.x             *= -direction;
        transform.localScale = scale;

        //移動
        _rb2.AddForce(moveVec.normalized * moveSpeed * 10, ForceMode2D.Force);
    }

    private void Update()
    {
        //画面外で魚を消す
        if (gameObject.transform.position.x < -6 || 6 < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
    
    public void SetVelocityZero()
    {
        //速度を0にして銛にくっつく
        _rb2.velocity = new Vector3(0, 0, 0);
        _rb2.isKinematic = true;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
    }
}
