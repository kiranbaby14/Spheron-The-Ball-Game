using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
    }


    //save the whole state of this savestate script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save",Helper.Serialize<SaveState>(state));

    }

    // load the previous saved state from the player prefs
    public void Load()
    {
        if(PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }

        else
        {
            state = new SaveState();
            Save();
            Debug.Log("no file found creating new");
        }
    }

    // check if the color is owned
    public bool IsColorOwned(int index)
    {
        return (state.colorOwned & (1 << index)) != 0;
    }



    public bool BuyColor(int index,int cost)
    {
        if(state.gold >= cost)
        {
            state.gold -= cost;
            UnlockColor(index);

            Save();

            return true;
        }
        else
        {
            return false;
        }
    }







    //unloock a color in the colorowned
    public void UnlockColor(int index)
    {
        state.colorOwned |= 1 << index;
    }



    //Resets the whole save file
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}
