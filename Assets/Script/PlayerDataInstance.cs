using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

/// <summary>
/// .jsonファイルでプレイヤーデータを保存する
/// </summary>
[Serializable]
public class PlayerDataInstance : ISerializationCallbackReceiver
{
    //プレイヤーデータの実態、初アクセス時にデータをロード
    private static PlayerDataInstance _instance = null;
    public static PlayerDataInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                Load();
            }
            return _instance;
        }
    }

    [SerializeField]
    private static string _jsonText = "";

    //================================================
    //保存されるデータ
    //================================================

    [SerializeField]
    int                             money;         // 所持金
    [SerializeField]
    string                          lanceName;  // 装備しているLanceStatusDataの名前
    [SerializeField]
    private string                  _fishDictJson = "";
    public Dictionary<string, Fish> FishDict = new Dictionary<string,Fish>();// 銛で突いた魚の名前と数を保存

    //================================================
    //シリアライズ、デシリアライズ時のコールバック
    //================================================

    /// <summary>
    /// PlayerData->Jsonに変換される前に実行される。
    /// </summary>
    public void OnBeforeSerialize()
    {
        //Dictionaryはそのまま保存されないので、個別にシリアライズしてテキストで保存
        _fishDictJson = Serialize(FishDict);
    }


    /// <summary>
    /// Json->PlayerDataに変換された後に実行される。
    /// </summary>
    public void OnAfterDeserialize()
    {
        //保存されているテキストがあればDictionaryにデシリアライズ
        if (!string.IsNullOrEmpty(_fishDictJson))
        {
            FishDict = Deserialize<Dictionary<string, Fish>>(_fishDictJson);
        }
    }

    /// <summary>
    /// 引数のオブジェクトをシリアライズして返す
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static string Serialize<T>(T obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream       = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return Convert.ToBase64String(memoryStream.GetBuffer());
    }
    /// <summary>
    /// 引数のテキストを指定されたクラスにデシリアライズして返す。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    private static T Deserialize<T>(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream       = new MemoryStream(Convert.FromBase64String(str));
        return (T)binaryFormatter.Deserialize(memoryStream);
    }

    //================================================
    //取得
    //================================================

    /// <summary>
    /// データを再読み込みする。
    /// </summary>
    public void Reload()
    {
        JsonUtility.FromJsonOverwrite(GetJson(), this);
    }

    /// <summary>
    /// データを読み込む。
    /// </summary>
    private static void Load()
    {
        _instance = JsonUtility.FromJson<PlayerDataInstance>(GetJson());
    }


    private static string GetJson()
    {
        //既にJsonを取得している場合はそれを返す。
        if (!string.IsNullOrEmpty(_jsonText))
        {
            return _jsonText;
        }

        //Jsonを保存している場所のパスを取得
        string filePath = GetSaveFilePath();

        //Jsonが存在するか調べてから取得し変換する。存在しなければ新たなクラスを作成し、それをJsonに変換する。
        if (File.Exists(filePath))
        {
            _jsonText = File.ReadAllText(filePath);
        }
        else
        {
            _jsonText = JsonUtility.ToJson(new PlayerDataInstance());
        }

        return _jsonText;
    }

    //================================================
    //保存
    //================================================

    /// <summary>
    /// データをJsonにして保存する。
    /// </summary>
    public void Save()
    {
        _jsonText = JsonUtility.ToJson(this);
        File.WriteAllText(GetSaveFilePath(), _jsonText);
    }

    //================================================
    //削除
    //================================================

    /// <summary>
    /// データをすべて削除し、初期化する。
    /// </summary>
    public void Delete()
    {
        _jsonText = JsonUtility.ToJson(new PlayerDataInstance());
        Reload();
    }

    //================================================
    //保存先のパス
    //================================================

    private static string GetSaveFilePath()
    {
        string filePath = "PlayerDataInstance";
        //確認しやすいようにエディタではAssetsと同じ改装に保存
        //それ以外ではApplication.persistentDataPath以下に保存するように。
#if UNITY_EDITOR
        filePath += ".json";
#else
        filePath = Application.persistentDataPath + "/" + filePath;
#endif
        Debug.Log(filePath);
        return filePath;
    }

    //================================================
    //PlayerDataUtility
    //================================================

    /// <summary>
    /// 所持金を取得する。
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return money;
    }

    /// <summary>
    /// 装備品の名前を取得する
    /// </summary>
    /// <returns></returns>
    public string GetLanceName()
    {
        return lanceName;
    }

    /// <summary>
    /// 銛で獲った魚の名前と数を取得する
    /// </summary>
    /// <returns></returns>
    public Dictionary<string,Fish> GetFish()
    {
        return FishDict;
    }


    /// <summary>
    /// 保存するデータを設定する。
    /// </summary>
    /// <param name="data"></param>
    public void SetPlayerData(PlayerData data)
    {
        LanceStatusData _lsd = data.GetLance();
        lanceName            = _lsd.GetEquipmentName();
        money                = data.GetMoney();
        FishDict             = data.GetFish();
    }
}
