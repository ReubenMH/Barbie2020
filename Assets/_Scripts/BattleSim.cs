using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    public GameObject vestigePrefab;

    private Character left;
    private Character right;

    void Start()
    {
        ExampleBattle();
    }

    void ExampleBattle()
    {
        Word wordOne = new Word("test1", 3, 2, 5, 1);
        Word wordTwo = new Word("test2", 2, 2, 5, 3);
        Word wordThree = new Word("test3", 2, 2, 5, 2);
        Word wordFour = new Word("test4", 1, 1, 5, 3);

        Vestige one = new Vestige();
        one.wordPositions = new List<Vector2>();
        one.aspects = new List<Word>();
        one.aspects.Add(wordOne);
        one.aspects.Add(wordTwo);
        one.aspects.Add(wordThree);
        one.wordPositions.Add(Vector2.zero);
        one.wordPositions.Add(Vector2.zero);
        one.wordPositions.Add(Vector2.zero);
        one.wordPositions.Add(Vector2.zero);

        Vestige two = new Vestige();
        two.wordPositions = new List<Vector2>();
        two.aspects = new List<Word>();
        two.aspects.Add(wordOne);
        two.aspects.Add(wordTwo);
        two.aspects.Add(wordFour);
        two.wordPositions.Add(Vector2.zero);
        two.wordPositions.Add(Vector2.zero);
        two.wordPositions.Add(Vector2.zero);
        two.wordPositions.Add(Vector2.zero);

        SimulateConflict(one, two);
    }

    public void SimulateConflict(Vestige blake, Vestige rose)
    {
        left = GameObject.Instantiate(vestigePrefab).GetComponent<Character>();
        right = GameObject.Instantiate(vestigePrefab).GetComponent<Character>();
        left.Initialize(true, blake, right);
        right.Initialize(false, rose, left);
        StartCoroutine(AnimateConflict(blake, rose));
    }

    public IEnumerator AnimateConflict(Vestige blake, Vestige rose)
    {
        blake.SetFullHP();
        rose.SetFullHP();
        int turn = 0;
        // blake = 0, rose = 1
        if (blake.GetStat(Word.WORD_STAT.DEX) < rose.GetStat(Word.WORD_STAT.DEX))
        {
            turn = 1;
        }
        int i = 0;
        while (blake.hp > 0 && rose.hp > 0)
        {
            if (turn == 0)
            {
                rose.hp -= blake.GetStat(Word.WORD_STAT.STR);
            }
            else if (turn == 1)
            {
                blake.hp -= rose.GetStat(Word.WORD_STAT.STR);
            }
            //if (i % 3 == 2)
            //{
            //    blake.hp += blake.GetStat(Word.WORD_STAT.WIT);
            //    if (blake.hp > blake.GetFullHP())
            //    {
            //        blake.SetFullHP();
            //    }
            //    rose.hp += rose.GetStat(Word.WORD_STAT.WIT);
            //    if (rose.hp > rose.GetFullHP())
            //    {
            //        rose.SetFullHP();
            //    }
            //}
            // Change the turn
            turn = (turn + 1) % 2;
            i += 1;

            if (turn == 0)
            {
                left.Attack();
                right.SetNewHealth((float)rose.hp / (float)rose.GetFullHP());
            }
            else
            {
                right.Attack();
                left.SetNewHealth((float)blake.hp / (float)blake.GetFullHP());
            }
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Battle ended");
    }
}
