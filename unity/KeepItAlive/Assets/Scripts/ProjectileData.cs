﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    public uint damage = 1;
    public float lifetime = 10.0f;
    public bool destroyAfterDamage = true;
    public float playerShove = 0.0f;
}
