﻿using UnityEngine;

public class NightClosingDoor : Door
{
    [SerializeField] private bool _openDuringNight;

    protected override void Awake()
    {
        base.Awake();
        
        var cycle = FindObjectOfType<DayNightCycle>(true);

        if (_openDuringNight)
        {
            cycle.Day += Close;
            cycle.Night += Open;
        }
        else
        {
            cycle.Day += Open;
            cycle.Night += Close;
        }
    }
}