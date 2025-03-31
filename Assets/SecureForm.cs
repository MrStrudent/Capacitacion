using UnityEngine;

public class SecureForm
{
    private WWWForm m_secureForm = null;
    private const string CONNECTION_PASSWORD = "82F4A74D993A5D5D9F324AED2C652";
    private const string IOS_PASSWORD = "NmS0dU7Lhcxu615037bmAB0rgvNVdEG9";
    private const string LINUX_PASSWORD = "JG-s^<63](+-m|)E:+oQq#gxAx1r=[";
    private const string WINDOWS_PASSWORD = "F849D";
    public WWWForm secureForm { get { return m_secureForm; } }
    public SecureForm()
    {
        m_secureForm = new WWWForm();
        m_secureForm.AddField("connectionPass", CONNECTION_PASSWORD);

#if UNITY_STANDALONE_WIN
        secureForm.AddField("os", "PC");
        secureForm.AddField("platformPass", WINDOWS_PASSWORD);

#endif
#if UNITY_IOS
        m_secureForm.AddField("os", "ios");
        m_secureForm.AddField("platformPass", IOS_PASSWORD);

#endif
#if UNITY_STANDALONE_LINUX
        secureForm.AddField("os", "Linux");
        secureForm.AddField("platformPass", LINUX_PASSWORD);

#endif
    }
}
