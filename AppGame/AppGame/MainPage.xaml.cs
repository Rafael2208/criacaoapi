using AppGame.Model;
using AppGame.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGame
{
    public partial class MainPage : ContentPage
    {
        private GameScore score;
        private GameScoreApi api;
        public MainPage()
        {
            InitializeComponent();
            api = new GameScoreApi();
        }

        private async void btLocalizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                score = await api.GetHighScore(Convert.ToInt32(entId.Text));
                if (score.id > 0)
                {
                    entHiScore.Text = score.highscore.ToString();
                    entGame.Text = score.game;
                    entName.Text = score.name;
                    entPhrase.Text = score.phrase;
                    entEmail.Text = score.email;
                    btSalvar.Text = "Atualizar";
                }
                else btSalvar.Text = "Cadastrar";
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "OK");
            }

        }

        private void btExcluir_Clicked(object sender, EventArgs e)
        {

        }

        private void btSalvar_Clicked(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            entId.Text = "";
            entHiScore.Text = "";
            entEmail.Text = "";
            entGame.Text = "";
            entName.Text = "";
            entPhrase.Text = "";


        }
    }
}
