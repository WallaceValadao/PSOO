using Android.App;
using Android.Widget;
using Android.OS;
using PSOO.Dominio;
using PSOO.App.Models;
using static Android.Views.View;
using Android.Views;
using System;
using PSOO.Servico.IServico;

namespace PSOO.App
{
    [Activity(Label = "PSOO.App", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginController : Activity
    {
        private IUsuarioServico usuarioServico;

        private EditText TxtLogin;
        private EditText TxtSenha;

        private TextView txtResposta;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.LoginView);

            var btnLogin = (Button)FindViewById(Resource.Id.btnLogin);
            var btnLimpar = (Button)FindViewById(Resource.Id.btnLimpar);
            var btnCadastrar = (Button)FindViewById(Resource.Id.btnCadastrar);

            btnLogin.Click += delegate { Logar(); };
            btnLimpar.Click += delegate { Limpar(); };
            btnCadastrar.Click += delegate { Cadastrar(); };

            this.TxtLogin = (EditText)FindViewById(Resource.Id.txtLogin);
            this.TxtSenha = (EditText)FindViewById(Resource.Id.txtSenha);
            this.txtResposta = (TextView)FindViewById(Resource.Id.txtResposta);

            this.usuarioServico = ManagerInjector.get().UsuarioServico();
        }

        private LoginModel getModelo()
        {
            return new LoginModel
            {
                Login = TxtLogin.Text,
                Senha = TxtSenha.Text
            };
        }

        private void Logar()
        {
            var modelo = getModelo();

            if(usuarioServico.VerificarLoginSenha(modelo.Login, modelo.Senha))
                StartActivity(typeof(MensagemController));

            txtResposta.Visibility = ViewStates.Visible;
            txtResposta.Text = "Login ou senha invalidos";
        }

        private void Limpar()
        {
            txtResposta.Visibility = ViewStates.Invisible;
            TxtLogin.Text = string.Empty;
            TxtSenha.Text = string.Empty;
        }

        private void Cadastrar()
        {

        }
    }
}

