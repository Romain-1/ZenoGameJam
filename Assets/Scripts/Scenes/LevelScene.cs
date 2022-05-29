using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScene : MonoBehaviour
{
    private int _mothCount = 0;
    private int _deadMoths = 0;
    private int _savedMoths = 0;

    public void AddMoth(int count = 1)
    {
        _mothCount += count;
    }

    public void MothDied()
    {
        _deadMoths += 1;
    }

    public void MothSaved()
    {
        _savedMoths += 1;
    }
}
