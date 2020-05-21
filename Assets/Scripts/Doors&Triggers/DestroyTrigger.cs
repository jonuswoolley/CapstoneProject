﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
