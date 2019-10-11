﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Empty,
    BasicFire,
    DoubleFire,
    Missile,
    Invulnerability
}

public class Inventory : MonoBehaviour
{
    public float m_DoubleFireTime;
    private struct InventorySlot
    {
        private ItemType m_CurrentItemType;
        public void SetCurrentItem(ItemType item)
        {
            m_CurrentItemType = item;
        }

        public ItemType GetCurrentItem()
        {
            return m_CurrentItemType;
        }
    }

    private InventorySlot m_PrimarySlot, m_SecondarySlot;
    void Start()
    {
        SetPrimarySlot(ItemType.BasicFire);
        SetSecondarySlot(ItemType.Empty);
    }

    public void SetPrimarySlot(ItemType item)
    {
        if(item == ItemType.BasicFire || item == ItemType.DoubleFire)
        {
            m_PrimarySlot.SetCurrentItem(item);
            if(item == ItemType.DoubleFire)
            {
                Invoke("SetBasicFire", m_DoubleFireTime);
            }
        }
    }

    public void SetSecondarySlot(ItemType item)
    {
        if (item == ItemType.Missile || item == ItemType.Invulnerability || item == ItemType.Empty)
        {
            m_SecondarySlot.SetCurrentItem(item);
        }
    }

    public ItemType GetPrimarySlot()
    {
        return m_PrimarySlot.GetCurrentItem();
    }

    public ItemType GetSecondarySlot()
    {
        return m_SecondarySlot.GetCurrentItem();
    }

    private void SetBasicFire()
    {
        m_PrimarySlot.SetCurrentItem(ItemType.BasicFire);
    }
}
