using System;
using Player.DTO;
using UnityEngine.UIElements;
using UnityEngine;
namespace SmallBiz.UIDoc
{
    public class WelcomeScreen : DocBase
    {
        LoginData _loginData;
        Button _btnLogin;
        TextField _inputEmail;
        TextField _inputPassword;
        protected override void Start()
        {
            try
            {
                base.Start();
                _btnLogin = (Button)GetElement<Button>("btn_login");
                _inputEmail = (TextField)GetElement<TextField>("input_email");
                _inputPassword = (TextField)GetElement<TextField>("input_password");
                _btnLogin.clicked += Login;

                _inputEmail.RegisterCallback<FocusInEvent>(e=> { RemoveError(_inputEmail); });
                _inputPassword.RegisterCallback<FocusInEvent>(e=> { RemoveError(_inputPassword); });
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        void Login()
        {
            ValidateField(_inputEmail);
            ValidateField(_inputPassword);
            var procceed = !VerifyEmptyField(_inputEmail.value) && !VerifyEmptyField(_inputPassword.value);
            if (!procceed)
                return;
            _loginData = new LoginData(_inputEmail.value, _inputPassword.value);
            Close();
        }
    }
}