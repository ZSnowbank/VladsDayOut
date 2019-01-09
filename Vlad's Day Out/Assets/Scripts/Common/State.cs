﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    public T m_owner;

    virtual public void Enter()
    {

    }

    virtual public void Update()
    {

    }

    virtual public void Exit()
    {

    }
}
