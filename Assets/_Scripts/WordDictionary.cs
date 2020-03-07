using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Json;
using System.Json.JsonSerializer;

public class WordDictionary : MonoBehaviour
{
    public WordDictionary Instance{
        get{
            return _inst;
        }
    }
    private WordDictionary _inst;

    public TextAsset wordDictFile;

    public Dictionary<string, Word> wordDict;

    private Word[] wordList;

    // Start is called before the first frame update
    void Start()
    {
        if(_inst == null){
            _inst = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }

        TestWordList();
    }

    void TestWordList(){
        wordList = new wordList[5];
        wordList[0] = new Word("cowardly", 4, 1, 1, 2);
        wordList[1] = new Word("aggressive", 3, 3, 1, 1);
        wordList[2] = new Word("fat", 1, 2, 4, 1);
        wordList[3] = new Word("quick", 5, 1, 1, 3);
        wordList[4] = new Word("dramatic", 4, 1, 1, 2);
    }

    void LoadWordDict(){
        wordList = JsonSerializer.Deserialize<Word[]>(wordDictFile);

        for(int i = 0; i < wordList.Length; i++){
            wordDict.Add(wordList[i].word, wordList[i]);
        }
    }

    void SaveWordDict(){
        string json = JsonSerializer.Serialize(wordList);

        Debug.Log(json);
    }
}
