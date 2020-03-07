using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vestige : MonoBehaviour
{
    public List<Word> aspects;

    public int hp;

    public void SetFullHP()
    {
        hp = GetStat((Word.WORD_STAT.CON));
    }

    public int GetStat(Word.WORD_STAT stat)
    {
        int total = 0;
        foreach (Word word in aspects)
        {
            total += word.getStat(stat);
        }
        return total;
    }
}
