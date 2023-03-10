using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitLoopAnimator : MonoBehaviour
{
    [SerializeField] Texture[] textures;
    [SerializeField] Material mat;
    [SerializeField] float fps;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int i = 0;
        while (true)
        {
            mat.SetTexture("_MainTex", textures[i]);
            yield return new WaitForSeconds(1 / fps);
            i++;
            if (i == textures.Length)
                i = 0;
        }
    }
}
