using UnityEngine;
using System.Collections;

public class UpsetRandom<T> : MonoBehaviour
{
    public static void Shuffle(T[] Source)
    {
        if (Source == null) return;

        int len = Source.Length;
        int r;
        T tmp;

        for (int i = 0; i < len - 1; i++)
        {
            r = Random.Range(i, len);
            if (i == r) continue;

            tmp = Source[i];
            Source[i] = Source[r];
            Source[r] = tmp;
        }
    }
}
