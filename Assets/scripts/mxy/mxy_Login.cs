using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mxy_Login : MonoBehaviour
{
    public InputField ifUser;                       //用户名输入框    
    public InputField ifPassword;                   //密码输入框         

    public Button btnLogin;                         //登录按钮

    public Toggle toggleRemeberPassword;            //记住密码
    public Button btnForgetPassword;                //忘记密码

    // Use this for initialization
    void Start ()
    {
        toggleRemeberPassword.isOn = false;
        ifPassword.contentType = InputField.ContentType.Password;

        EventTriggerListener.GetListener(btnLogin.gameObject).onPointerClick +=
            delegate(GameObject go, PointerEventData data)
            {
                OnBtnLoginClick();
            };
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 登录按钮点击事件
    /// </summary>
    void OnBtnLoginClick(GameObject go = null,PointerEventData data = null)
    {
        SendMessageUpwards("SecondClickHandler", mxy_ProjectConst.Login);
    }


    /// <summary>
    /// 当记住密码切换状态
    /// </summary>
    void OnToggleRemeberPasswordChange( bool bIsOn)
    {
        
    }

    /// <summary>
    /// 忘记密码按钮点击事件
    /// </summary>
    void OnBtnForgetPasswordClick()
    {
        
    }

    /// <summary>
    /// 当输入完用户名时
    /// </summary>
    /// <param name="strContent"></param>
    void OnUserInputFieldEndEdit(string strContent)
    {
        
    }

    /// <summary>
    /// 当输入完密码时
    /// </summary>
    /// <param name="strContent"></param>
    void OnPasswordInputFieldEndEdit(string strContent)
    {

    }
}
