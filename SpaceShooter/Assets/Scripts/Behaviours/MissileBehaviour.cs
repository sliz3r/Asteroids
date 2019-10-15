﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    //Public
    public float m_Speed;
    public float m_TimeToExplode;
    public int m_Damage;
    public GameObject m_Explosion;

    //Private
    private Vector3 m_Direction;
    private Rigidbody2D m_RigidBody2D;

    void Start()
    { 
        m_Direction = Vector2.right;
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        Invoke("Explode", m_TimeToExplode);
    }

    void FixedUpdate()
    {
        m_RigidBody2D.AddForce(m_Direction * m_Speed);
    }

    void Explode()
    {
        Instantiate(m_Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //TODO update this in the future
        if (collider.gameObject.tag == "Enemy")
        {
            Explode();
        }
    }
}