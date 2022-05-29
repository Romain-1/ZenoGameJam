using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public LevelScene _scene;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<MothController>(out MothController moth))
        {
            _scene.MothSaved();
            GameObject.Destroy(moth.gameObject);
        }
    }
}
