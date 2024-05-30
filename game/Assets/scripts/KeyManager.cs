using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyManager
{
    private static bool[] keys = new bool[4];
    public static void pickUpKey(int index)
    {
        keys[index] = true;
    }

    public static bool HasKey(int keyIndex)
    {
        if (keyIndex >= 0 && keyIndex < keys.Length)
        {
            return keys[keyIndex];
        }
        return false;
    }
}
