using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class TitleScreenScript : MonoBehaviour
{
    public Button[] items_buttons;
    public Dropdown[] items_dropdown;

    public Button[] colors_buttons;
    public bool[] button_boolens;

    public Dropdown Radius_dropdown;
    Dropdown.OptionData option_data;
    private void Start()
    {
        Radius_dropdown.ClearOptions();
        for (int i = 1; i < 50; i++)
        {
            option_data = new Dropdown.OptionData($"{i} unit");
            Radius_dropdown.options.Add(option_data);
        }
        button_boolens = new bool[items_buttons.Length];
        item_clicked();
        color_clicked();
        
    }
    void color_clicked()
    {
        for (int i = 0; i < colors_buttons.Length; i++)
        {
            int copy = i;
            colors_buttons[copy].onClick.AddListener(delegate 
            {
                for(int j = 0; j < items_buttons.Length; j++)
                {
                    if (button_boolens[j])
                    {
                        items_buttons[j].image.color = colors_buttons[copy].image.color;
                        button_boolens[j] = false;
                        items_buttons[j].GetComponentInChildren<Text>().text = "";
                    }
                }
            });
        }
    }
    void item_clicked()
    {
        for (int i = 0; i < items_buttons.Length; i++)
        {
            int copy = i;
            items_buttons[copy].onClick.AddListener(delegate {
                button_boolens[copy] = !button_boolens[copy];

                if (button_boolens[copy])
                {
                    items_buttons[copy].GetComponentInChildren<Text>().text = "pick";

                }
                else items_buttons[copy].GetComponentInChildren<Text>().text = "";
            });
        }
            
    }
    void select_colors() {
        InputData.Instance.first = items_buttons[0].image.color;
        InputData.Instance.second = items_buttons[1].image.color;
        InputData.Instance.decor1 = items_buttons[2].image.color;
        InputData.Instance.decor2 = items_buttons[3].image.color;
        InputData.Instance.decor3 = items_buttons[4].image.color;
        InputData.Instance.decor4 = items_buttons[5].image.color;
    }
    public void StartButton()
    {
        InputData.Instance.Sphere_radius = Radius_dropdown.value + 1; // dropdown.value works like index so starts with 0.
        InputData.Instance.Scale_first = items_dropdown[0].value+1;
        InputData.Instance.Scale_second = items_dropdown[1].value +1;
        InputData.Instance.Scale_decor1 = items_dropdown[2].value +1;
        InputData.Instance.Scale_decor2 = items_dropdown[3].value +1;
        InputData.Instance.Scale_decor3 = items_dropdown[4].value +1;
        InputData.Instance.Scale_decor4 = items_dropdown[5].value +1;
       select_colors();
        // this line will take us to the main Scene which is (sampleScene) by clicking on 'Start' button
        SceneManager.LoadScene("SampleScene");
    }
}
