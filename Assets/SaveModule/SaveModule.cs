using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class SaveModule : MonoBehaviour
{
    /** 저장 모듈 **/
    /*
    
    <기능>
        - 로컬 저장 (저장할 데이터) 리스트 데이터, 배열 데이터, 기본 데이터 저장 메소드 따로 구현
        - 로컬 데이터 로드 : json으로 묶어서 한꺼번에 로드?

    */

    public string dataPath { get { return Application.persistentDataPath + "/Resources/SaveData"; } }

    public void Save<T>(string _key, T _data)
    {
        string sdata = JsonUtility.ToJson(_data);
        string path = Path.Combine(dataPath, _key + ".json");
        File.WriteAllText(path, sdata);
    }

    public T Load<T>(string _key)
    {
        string sdata = Resources.Load<TextAsset>("SaveData/" + _key).text;
        return JsonUtility.FromJson<T>(sdata);
    }
}
