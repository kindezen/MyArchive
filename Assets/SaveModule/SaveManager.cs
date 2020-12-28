using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class SaveManager : MonoBehaviour
{
    /** 데이터 저장용 클래스 **/
    /*
     
    System.IO의 Path.Combine(A, B)                         경로를 합칠 수 있다.
    JsonUtility.ToJson(데이터, true)                       객체를 string으로 변환한다.
    JsonUtility.FromJson<객체타입>(string화된 데이터)       객체를 뽑아낸다.
    File.WriteAllText(경로, 문자열)                        경로에 있는 파일에 문자열을 덮어쓴다.
    File.ReadAllText(경로)                                 경로에 있는 파일의 문자열을 뽑아낸다.
     
    */

    public PlayerData[] playerData;

    [ContextMenu("Save Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonMapper.ToJson(playerData); //Par1: 변환할 객체, Par2: 이뿌게 정렬 여부
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Read Json Data")]
    void LoadPlayerDataToJson()
    {
        
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonMapper.ToObject<PlayerData[]>(jsonData);
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int age;
    public int level;
    public bool isDead;
    public string[] items;
}
