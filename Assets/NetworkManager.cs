using System;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(userName, email, pass, response));
    }
    private IEnumerator CO_CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        SecureForm form = new SecureForm();
        form.secureForm.AddField("username", userName);
        form.secureForm.AddField("email", email);
        form.secureForm.AddField("password", pass);

        WWW w = new WWW("http://localhost/Capacitacion/createUser.php", form.secureForm);
        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));
    }
    public void CheckUser(string userName, string pass, Action<Response> response)
    {
        StartCoroutine (CO_CheckUser( userName, pass, response));
    }
    private IEnumerator CO_CheckUser(string userName, string pass, Action<Response > response)
    {
        SecureForm form = new SecureForm();
        form.secureForm.AddField("username", userName);
        form.secureForm.AddField("pass", pass);
        WWW w = new WWW("http://localhost/Capacitacion/checkUser.php", form.secureForm);
        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<Response> (w.text));
    }
}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "Error usuario ya existente";
}
