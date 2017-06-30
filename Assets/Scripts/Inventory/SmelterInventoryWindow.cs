using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class SmelterInventoryWindow : InventoryWindow
{

    public ItemSlot inputSlot;
    public ItemSlot outputSlot;

    private GameObject inputSlotIcon;
    private GameObject outputSlotIcon;

    public ProgressBar progressBar;

    // Use this for initialization
    void Start()
    {
        if (inventory == null)
        {
            inventory = gameObject.AddComponent<BaseInventory>();
            inventory.Resize(2);
        }
        inventory.OnInventoryChanged += OnInventoryChanged;

        inputSlotIcon = inputSlot.transform.Find("ItemIcon").gameObject;
        outputSlotIcon = outputSlot.transform.Find("ItemIcon").gameObject;

        inputSlot.invIndex = 0;
        outputSlot.invIndex = 1;

        inputSlotIcon.SetActive(false);
        outputSlotIcon.SetActive(false);
    }

    public void SetUpWidnow()
    {
        if (inputSlot.Item != null)
        {
            inputSlotIcon.GetComponent<Image>().sprite = inputSlot.Item.ItemIcon;
            inputSlotIcon.SetActive(true);
        }
        else
            inputSlotIcon.SetActive(false);

        if (outputSlot.Item != null)
        {
            outputSlotIcon.GetComponent<Image>().sprite = outputSlot.Item.ItemIcon;
            outputSlotIcon.SetActive(true);
        }
        else
            outputSlotIcon.SetActive(false);
    }

    public override bool Move(ItemSlot source, ItemSlot dest)
    {
        bool success = true;
        if (dest != outputSlot)
        {
            inventory.MoveItem(source, dest);
        }

        SetUpWidnow();
        return success;
    }

    public void OnSmeltClick()
    {
        List<BaseItem> inputs = new List<BaseItem>();
        inputs.Add(inputSlot.Item);
        Recipe recipe = RecipeDatabase.Instance.MatchRecipe(inputs);
        if (recipe != null)
        {
            inventory.RemoveItem(0);
            OnInventoryChanged();
            StartCoroutine(Smelt(5,recipe,1));            
        }

        if (progressBar != null)
            progressBar.SetProgress(0.5f);
    }

    private void OnInventoryChanged()
    {
        SetUpWidnow();
    }

    IEnumerator Smelt(float t, Recipe recipe, int qty)
    {
        float curTime = 0;

        while (curTime < 5f)
        {
            progressBar.SetProgress(curTime / t);
            curTime += Time.smoothDeltaTime;
            yield return null;
        }

        inventory.AddItemToInventory(recipe.RecipeProduct, qty);
        OnInventoryChanged();
    }
}
