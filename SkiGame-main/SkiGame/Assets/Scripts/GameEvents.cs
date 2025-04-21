using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RaceEvent();

    public static event RaceEvent startRace;
    public static event RaceEvent raceEnd;
    public static event RaceEvent racePenalty;
    public static event RaceEvent QuitGame;

    public static void CallRaceStart()
    {
        if (startRace != null)
        {
            startRace();
        }
    }

    public static void CallRaceEnd()
    {
        if (raceEnd != null)
        {
            raceEnd();
        }
    }

    public static void CallPenalty()
    {
        if (racePenalty != null)
        {
            racePenalty();
        }
    }

    public static void CallQuit()
    {
        if (QuitGame != null)
        {
            QuitGame();
        }
    }
}
