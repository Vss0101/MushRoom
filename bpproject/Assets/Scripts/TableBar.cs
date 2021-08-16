using System.Net.Mime;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 导航栏组件类。
/// </summary>
public class TableBar : MonoBehaviour
{
    #region 可视变量
    public int size = 0;
    public int defaultIndex = 0;
    public Button[] buttons = new Button[100];
    public GameObject[] panels = new GameObject[100];

    #endregion

    #region 成员变量
    private int selected = 0;   // 当前选择的面板序号
    #endregion

    #region 私有方法
    /// <summary>
    /// 脚本实例化后立即触发。
    /// </summary>
    private void Awake()
    {
        selected = defaultIndex;
        // 绑定按钮监听事件
        for (int i = 0; i < size; i++)
        {
            int temp = i;
            panels[temp].SetActive(false);
            buttons[temp].onClick.AddListener(delegate () { OnClick(temp); });
        }
    }

    /// <summary>
    /// 当脚本生效时触发。
    /// </summary>
    private void OnEnable()
    {
        // 仅激活默认面板
        if(defaultIndex >= 0)
        {
            SelectPanel(defaultIndex);
        }
        
    }

    /// <summary>
    /// 按钮被单击时触发。
    /// </summary>
    /// <param name="index">按钮序号。</param>
    private void OnClick(int index)
    {
        SelectPanel(index);
    }

    /// <summary>
    /// 切换面板。
    /// </summary>
    /// <param name="index">面板序号。</param>
    private void SelectPanel(int index)
    {
        if(selected < 0){
            selected = 0;
        }
        panels[selected].SetActive(false);
        panels[index].SetActive(true);
        // 点击换图
        if(index == 0){
            tranTo(selected);
            buttons[index].image.sprite = Resources.Load<Sprite>("左边按钮框2");
        }
        else if(index == 1){
            tranTo(selected);
            buttons[index].image.sprite = Resources.Load<Sprite>("中间按钮框2");
        }
        else{
            tranTo(selected);
            buttons[index].image.sprite = Resources.Load<Sprite>("右边按钮框2");
        }

        selected = index;
    }

    private void tranTo(int i){
        if(i == 0){
            buttons[selected].image.sprite = Resources.Load<Sprite>("左边按钮框");
        }
        else if(i == 1){
            buttons[selected].image.sprite = Resources.Load<Sprite>("中间按钮框");
        }
        else{
            buttons[selected].image.sprite = Resources.Load<Sprite>("右边按钮框");
        }
    }

    #endregion
}
