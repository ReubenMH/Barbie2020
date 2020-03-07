using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    public void SimulateConflict(Vestige blake, Vestige rose)
    {
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
            if (i % 3 == 0)
            {
                blake.hp += blake.GetStat(Word.WORD_STAT.WIT);
                rose.hp += rose.GetStat(Word.WORD_STAT.WIT);
            }
            // Change the turn
            turn = (turn + 1) % 2;
            i += 1;

            yield return new WaitForSeconds(1);
        }
    }
}
