using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public List<FishStatusData> fishStatusDatas;
    static List<FishStatusData> fishDatas;
    public GameObject       timeKeeper;
    TimeKeeper              timeKeeperScript;
    public float            spawnSpan;
    public float            spanCoefficient;
    float                   deltaS;
    float                   deltaM;
    float                   deltaL;
    float                   deltaR;
    int                     px;
    float                   py;
    public static string    sceneName;
    public int              randomMax;
    public float            redSpan;
    int                     redCount;

    void Start()
    {
        if (timeKeeper == null)
            this.timeKeeper = GameObject.Find("TimeKeeper");
        this.timeKeeperScript = timeKeeper.GetComponent<TimeKeeper>();
        fishDatas = new List<FishStatusData>(fishStatusDatas);
        Debug.Log(fishDatas);

        sceneName = SceneManager.GetActiveScene().name;
        redCount = 0;
    }

    void Update()
    {
        if (timeKeeperScript.GetStartFlag())
        {
            this.deltaS += Time.deltaTime;
            this.deltaM += Time.deltaTime;
            this.deltaL += Time.deltaTime;
            this.deltaR += Time.deltaTime;
        }

        //出現率が高い魚の生成
        if (this.deltaS > this.spawnSpan + Random.Range(-1,1))
        {
            this.deltaS = 0;
            GameObject goS = Instantiate(fishStatusDatas[0].GetFishPrefabs()) as GameObject;
            goS.transform.position = RandomPos();
        }
        //出現率普通の魚の生成
        if (this.deltaM > this.spawnSpan * spanCoefficient + Random.Range(-1, 1))
        {
            this.deltaM = 0;
            GameObject goM = Instantiate(fishStatusDatas[1].GetFishPrefabs()) as GameObject;
            goM.transform.position = RandomPos();
        }
        //出現率が低い魚の生成
        if (this.deltaL > this.spawnSpan * spanCoefficient * spanCoefficient + Random.Range(-1, 1))
        {
            this.deltaL = 0;
            GameObject goL = Instantiate(fishStatusDatas[2].GetFishPrefabs()) as GameObject;
            goL.transform.position = RandomPos();
        }
        if (deltaR > redSpan && redCount < 3)
        {
            deltaR = 0;
            int random = Random.Range(0, randomMax);
            if(random == 0)
            {
                GameObject goR = Instantiate(fishStatusDatas[3].GetFishPrefabs()) as GameObject;
                goR.transform.position = RandomPos();
                redCount++;
            }
        }

    }

    //生成位置の決定
    Vector3 RandomPos()
    {
        Vector3 vec;

        vec.x = Random.Range(0, 2);
        if (vec.x == 0)
        {
            vec.x = -1;
        }
        vec.x *= 5;
        vec.y  = Random.Range(-2, 5);
        vec.z  = 0.0f;

        return vec;
    }

    static public List<FishStatusData> GetFishData()
    {
        return fishDatas;
    }
}
