using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFish : MonoBehaviour
{
    GameObject                  playerData;
    PlayerData                  playerDataScript;
    LanceStatusData             lanceData;
    Collider2D                  _col2;
    Rigidbody2D                 _rb;
    AudioSource                 audioSource;
    public List<FishStatusData> fishStatusDatas;
    public AudioClip            getSound;
    public AudioClip            notGetSound;
    int                         fishLimit;
    int                         debugFishLimit;

    // Start is called before the first frame update
    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        lanceData        = playerDataScript.GetLance();
        fishLimit        = lanceData.GetFishMax();
        _col2            = GetComponent<Collider2D>();
        _rb              = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int childCount = transform.childCount;
        //取得上限に達していたら素通り
        if (childCount >= fishLimit)
            return;

        //魚のタグを取得してそれぞれ処理
        if (collision.tag == fishStatusDatas.Find(f => f.GetFishType().ToString() == collision.tag).GetFishType().ToString())
        {
            //プレイヤーの持つ装備の貫通力と魚の硬さを比較
            //貫通力が硬さを下回るなら銛を戻す
            if (fishStatusDatas.Find(f => f.GetFishType().ToString() == collision.gameObject.tag).GetDefPower() > lanceData.GetPenetration())
            {
                gameObject.GetComponent<GamePlayerController>().returnLance();
                audioSource.PlayOneShot(notGetSound);
                return;
            }
            collision.transform.parent.GetComponent<Movement>().SetVelocityZero();
            collision.transform.localPosition = new Vector3(0, 0, 0);
            collision.transform.parent        = gameObject.transform;
            audioSource.PlayOneShot(getSound);
        }
    }
}
