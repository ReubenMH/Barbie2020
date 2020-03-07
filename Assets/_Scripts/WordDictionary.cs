using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    [System.Serializable]
    public class WordCollection{
        public Word[] words;
    }

    public static WordDictionary Instance{
        get{
            return _inst;
        }
    }
    private static WordDictionary _inst;

    public TextAsset wordDictFile;

    public Dictionary<string, Word> wordDict;

    [SerializeField]
    private WordCollection wordList;

    // Start is called before the first frame update
    void Start()
    {
        if(_inst == null){
            _inst = this;
            DontDestroyOnLoad(gameObject);
            LoadWordDict();
        }else{
            Destroy(gameObject);
        }
    }

    void TestWordList(){
        wordList.words = new Word[5];
        wordList.words[0] = new Word("cowardly", 1, -2, -2, 1);
        wordList.words[1] = new Word("aggressive", 1, 1, -2, -2);
        wordList.words[2] = new Word("fat", -2, 0, 2, -2);
        wordList.words[3] = new Word("quick", 3, -2, -2, 1);
        wordList.words[4] = new Word("dramatic", 2, -2, -2, 0);

        SaveWordDict();
    }

    void LoadWordDict(){
        wordList = JsonUtility.FromJson<WordCollection>(wordDictFile.ToString());
        wordDict = new Dictionary<string, Word>();

        for(int i = 0; i < wordList.words.Length; i++){
            wordDict.Add(wordList.words[i].word, wordList.words[i]);
        }
    }

    void SaveWordDict(){
        string json = JsonUtility.ToJson(wordList);

        Debug.Log(json);
    }

    public static Word[] GetRandomWords(int amount){
        List<int> wordsSelected = new List<int>();

        Word[] words = new Word[amount];
        for(int i = 0; i < words.Length; i++){
            int wordIndex = Random.Range(0, Instance.wordList.words.Length);
            while(wordsSelected.Contains(wordIndex)){
                wordIndex = Random.Range(0, Instance.wordList.words.Length);
            }

            words[i] = Instance.wordList.words[wordIndex];
            wordsSelected.Add(wordIndex);
        }

        return words;
    }
}
