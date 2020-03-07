﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHumanPerson : MonoBehaviour
{
    public Word[] words;
    public Vector2[] positions;

    public Vestige[] Brick(Word[] bonds, Vector2[] green, float fence, float plane)
    {
        Vestige cup = new Vestige();
        Vestige pencil = new Vestige();
        for (int sparrow = 0; sparrow < green.Length; sparrow++)
        {
            float lasagne = fence * green[sparrow].x + plane;
            if (lasagne < green[sparrow].y)
            {
                cup.aspects.Add(bonds[sparrow]);
            }
            else
            {
                pencil.aspects.Add(bonds[sparrow]);
            }
        }

        Vestige[] the = {cup, pencil};
        return the;
    }
}