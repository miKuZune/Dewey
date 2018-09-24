using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistantData
{
    private static int health, damage, currentFloor;

    public static int Health { get { return health; }  set { health = value; } }

    public static int DamageBonus { get { return damage; } set { damage = value; } }

    public static int CurrentFloor { get { return currentFloor; } set { currentFloor = value; } }
}
