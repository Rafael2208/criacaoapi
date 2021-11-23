using AppGame.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppGame.Services
{
    public class GameScoreApi
    {
        const String URL = "https://restdfilitto.herokuapp.com/highscores";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;

        }

        public async Task<List<GameScore>> GetHighScores()
        {
            HttpClient client = GetClient();
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) // codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GameScore>>(content);
            }
            return new List<GameScore>();
        }

        public async Task<GameScore> GetHighScore(int Id)
        {
            String dados = URL + "?id=" + Id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            if (response.IsSuccessStatusCode) // codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<GameScore>>(content);
                return games[0];
            }
            return new GameScore();
        }

        public async Task CreateHighScore(GameScore game)
        {
            String dados = URL;
            string json = JsonConvert.SerializeObject(game);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);
        }

        public async Task UpdateHighScore(GameScore game)
        {
            String dados = URL + "/" + game.id;
            string json = JsonConvert.SerializeObject(game);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados,content);
            
        }

        public async Task DeleteHighScore(int Id)
        {
            String dados = URL + "/" + Id.ToString();
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}
