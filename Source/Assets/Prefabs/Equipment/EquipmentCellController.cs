﻿using UnityEngine;
using System.Collections;
using System;

public class EquipmentCellController : CellController
{
	#region Properties
	#region Public
	public ItemType TypeItem;
	public GameObject BackgroundImage;
	#endregion
	#region Private

	#endregion
	#endregion

	#region Methods
	#region Public
	/// <summary>
	/// Положить предмет в ячейку с определением соответствия типа ячейки и предмета.
	/// </summary>
	/// <param name="item">Предмет.</param>
	/// <returns>В случаи удачного действия возвращает true.</returns>
	public override bool SetItem(ItemController item)
	{
		if (item != null)
		{
			if (item.BaseItem == null)
				throw new NullReferenceException("Отсутствует ссылка на базовый предмет.");
			if (item.BaseItem.GetItemType() != TypeItem)
				return false;
		}
		return base.SetItem(item);
	}
	#endregion
	#region Private
	private void OnEnable()
	{
		OnChangeItem += ChangeItem;
	}

	private void OnDisable()
	{
		OnChangeItem -= ChangeItem;
	}

	private void ChangeItem(ItemController item)
	{
		BackgroundImage.SetActive(item == null);
    }
	#endregion
	#endregion
}