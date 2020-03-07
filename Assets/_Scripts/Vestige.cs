using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vestige
{
    public List<Word> aspects;
    public List<Vector2> wordPositions;

    public int hp;

    public Vestige()
    {
        aspects = new List<Word>();
        wordPositions = new List<Vector2>();
    }

    public void SetFullHP()
    {
        hp = GetStat((Word.WORD_STAT.CON));
    }

    public int GetFullHP()
    {
        return GetStat((Word.WORD_STAT.CON));
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
