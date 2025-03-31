using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private InputField m_Renterpass = null;
    [SerializeField] private InputField m_text = null;
    private NetworkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitRegister()
    {
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "")
        {
            m_text.text = "Favor de llenar los campos ";
            return;
        }
        if(m_password.text == m_Renterpass.text)
        {
            m_text.text = "Procesando. . .";
            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_password.text, delegate(Response response)
            {
                m_text.text = response.message;
            });
        }
        else
        {
            m_text.text = "Verificar contraseñas";
        }
    }
    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }
    public void ShowRegister()
    {
        m_registerUI.SetActive(true );
        m_loginUI.SetActive(false);
    }
}
