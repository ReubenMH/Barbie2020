using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHumanPerson : MonoBehaviour
{
    public BattleSim battleSim;
    public Word[] words;
    public Vector2[] positions;

    public void MakeVestiges(float gradient, float intercept) {
        Vestige[] vestiges = Brick(words, positions, gradient, intercept);
        battleSim.SimulateConflict(vestiges[0], vestiges[1]);
    }

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
                cup.wordPositions.Add(green[sparrow]);
            }
            else
            {
                pencil.aspects.Add(bonds[sparrow]);
                pencil.wordPositions.Add(green[sparrow]);
            }
        }

        Vestige[] the = {cup, pencil};
        return the;
    }
}
