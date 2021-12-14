using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface hidame
{
    void hidame_01(int damage);
}

public interface death
{
    void death_01();
}

public interface Move
{
    bool MoveEnemy(Vector3 _pos);
}
