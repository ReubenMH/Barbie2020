using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Word
{
   public enum WORD_STAT {DEX = 0, STR = 1, CON = 2, WIT = 3};
   
   public string word;
   
   public int[] stats;

   public int getStat(WORD_STAT stat){
      return stats[(int)stat];
   }

   public Word(string word, int dex, int str, int con, int wit){
      this.word = word;
      this.stats = new int[4];
      this.stats[0] = dex;
      this.stats[1] = str;
      this.stats[2] = con;
      this.stats[3] = wit;
   }
}
