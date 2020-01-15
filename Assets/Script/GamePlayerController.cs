using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController : MonoBehaviour
{
    public GameObject evaluation;
    SetEvaluationText evaTextScript;
    LanceStatusData   lanceData;
    GameObject        playerData;
    PlayerData        playerDataScript;
    public float      coefficient;//銛を飛ばす速度係数
    public GameObject timeKeeper;
    public GameObject gameDirector;
    public AudioClip  throwing;
    CalcPoint         calcPointScript;
    float             moveSpeed;//移動速度
    TimeKeeper        timeKeeperScript;
    Vector3           endPos;
    Vector3           startPos;
    Vector3           vec;
    bool              goFlag;
    bool              backFlag;
    float             startTime;
    float             journeyLength;
    float             fracJourney;
    float             radius;
    Rigidbody2D       _rb;
    AudioSource       audioSource;

    void Start()
    {
        playerData = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        audioSource = GetComponent<AudioSource>();

        if (timeKeeper == null)
            timeKeeper = GameObject.Find("TimeKeeper");

        timeKeeperScript = timeKeeper.GetComponent<TimeKeeper>();

        if (gameDirector == null)
            gameDirector = GameObject.Find("GameDirector");

        calcPointScript = gameDirector.GetComponent<CalcPoint>();
        
        lanceData = playerDataScript.GetLance();
        gameObject.GetComponent<SpriteRenderer>().sprite = lanceData.GetLanceImage();
        moveSpeed = lanceData.GetMoveSpeed();

        evaTextScript = evaluation.GetComponent<SetEvaluationText>();

        _rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
        startPos    = gameObject.transform.position;
        goFlag      = false;
        backFlag    = false;
        fracJourney = 0f;
    }

    void Update()
    {
        //銛が動いていない&左クリックで処理 ゲームスタートで処理開始
        if (Input.GetMouseButtonDown(0) && !goFlag && !backFlag && timeKeeperScript.GetStartFlag())
        {
            //マウスの座標を保存
            endPos   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0f;
            audioSource.PlayOneShot(throwing);

            //飛ばす方向に回転
            radius = GetRadius(startPos, endPos);
            transform.Rotate(new Vector3(0,0, radius - 90));

            startTime = Time.time;
            goFlag    = true;
        }
        //クリックした地点に向かっているとき
        if (goFlag)
        {
            GetComponent<Collider2D>().enabled = true;
            //移動ベクトルの計算
            CalcVec(startPos, endPos, coefficient);
            //mousePosについたら処理
            if (fracJourney > 1)
            {
                goFlag      = false;
                backFlag    = true;
                startTime   = Time.time;
                fracJourney = 0;
            }
        }
        //スタート地点に戻るとき
        if (backFlag)
        {
            GetComponent<Collider2D>().enabled = false;
            CalcVec(endPos, startPos);
            if (fracJourney > 1)
            {
                backFlag = false;
                if (gameObject.transform.childCount > 0)
                {
                    evaTextScript.SetActiveAndObject(SetEvaText(transform.childCount));
                }

                //子を全部削除
                foreach (Transform child in gameObject.transform)
                {
                    calcPointScript.AddPoint(child.gameObject);
                    Destroy(child.gameObject);
                }
                //角度を元に戻す
                transform.Rotate(new Vector3(0, 0, 90 - radius));
                fracJourney = 0;
            }
        }
        if (goFlag || backFlag)
        {
            //移動処理
            _rb.MovePosition(vec);
        }
        //Debug.Log(mousePos);
    }

    void CalcVec(Vector3 posA, Vector3 posB, float coefficient = 1)
    {
        //一定速度で現在地から目的地へ移動
        float distCovered = (Time.time - startTime) * moveSpeed * coefficient;
        journeyLength     = Vector3.Distance(startPos, endPos);
        fracJourney       = distCovered / journeyLength;

        vec = Vector3.Lerp(posA, posB, fracJourney);
    }

    float GetRadius(Vector3 p1, Vector3 p2)
    {
        float dx  = p2.x - p1.x;
        float dy  = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);

        return rad * Mathf.Rad2Deg;
    }

    string SetEvaText(int childCount)
    {
        string evaText;
        int fishMax = lanceData.GetFishMax();
        if (childCount == fishMax && childCount > 1)
        {
            evaText = "大漁";
        }
        else
        {
            evaText = "獲得";
        }

        return evaText;
    }


    /// <summary>
    /// 銛の移動を逆向きに変える（最初の位置に戻す）
    /// </summary>
    public void returnLance()
    {
        goFlag      = false;
        backFlag    = true;
        startTime   = Time.time;
        fracJourney = 0;
        endPos      = gameObject.transform.position;
    }
}
