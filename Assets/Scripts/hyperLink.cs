using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperLink : MonoBehaviour
{
    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
