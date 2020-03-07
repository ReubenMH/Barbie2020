using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
   public enum WORD_STAT {DEX = 0, STR = 1, CON = 2, WIT = 3};
   public string word;
   public int[] stats;

   public int getStat(WORD_STAT stat){
      return stats[(int)stat];
   }
}
