using Precificador.Application.Model;

using RestSharp;

namespace Precificador.Inicializador
{
    public class ColecaoInit
    {
        private List<Colecao> colecoes =
        [
            new Colecao { Nome = "Mulher 2025", Ano = 2025 },
            new Colecao { Nome = "Volta às Aulas 2025", Ano = 2025 },
            new Colecao { Nome = "Coleção 2025", Ano = 2025 },
            new Colecao { Nome = "Dininha", Ano = 2024 },
            new Colecao { Nome = "Kraft", Ano = 2022 },
            new Colecao { Nome = "Couro", Ano = 2024 },
            new Colecao { Nome = "Crochê", Ano = 2020 },
            new Colecao { Nome = "Bebê", Ano = 2020 },
            new Colecao { Nome = "Casamento", Ano = 2020 },
            new Colecao { Nome = "Trevo Saúde", Ano = 2020 },
            new Colecao { Nome = "Fofurinhas", Ano = 2022 },
            new Colecao { Nome = "Costura Criativa", Ano = 2017 },
            new Colecao { Nome = "Sacolas em Papel", Ano = 2020 },
            new Colecao { Nome = "Sacolas 60", Ano = 2020 },
            new Colecao { Nome = "Sacolas 40", Ano = 2020 },
            new Colecao { Nome = "Arraiá 2024", Ano = 2024 },
            new Colecao { Nome = "Mães 2024", Ano = 2024 },
            new Colecao { Nome = "Páscoa 2024", Ano = 2024 },
            new Colecao { Nome = "Mulher 2024", Ano = 2024 },
            new Colecao { Nome = "Volta às Aulas 2024", Ano = 2024 },
            new Colecao { Nome = "Coleção 2024", Ano = 2024 },
            new Colecao { Nome = "Pais 2023", Ano = 2023 },
            new Colecao { Nome = "Namorados 2023", Ano = 2023 },
            new Colecao { Nome = "Mães 2023", Ano = 2023 },
            new Colecao { Nome = "Páscoa 2023", Ano = 2023 },
            new Colecao { Nome = "Mulher 2023", Ano = 2023 },
            new Colecao { Nome = "Volta às Aulas23", Ano = 2023 },
            new Colecao { Nome = "Coleção 2023", Ano = 2023 },
            new Colecao { Nome = "Natal 2022", Ano = 2022 }
        ];

        public void Inicializar()
        {
            foreach (var colecao in colecoes)
            {
                if (!VerificaExistencia(colecao.Nome))
                {
                    IncluirColecao(colecao);
                }
            }
        }

        private void IncluirColecao(Colecao colecao)
        {
            var options = new RestClientOptions("https://localhost:7013");
            var client = new RestClient(options);
            var request = new RestRequest("/api/Colecao", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\"nome\": \"" + colecao.Nome + "\", \"ano\": " + colecao.Ano.ToString() + @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private bool VerificaExistencia(string nome)
        {
            var options = new RestClientOptions("https://localhost:7013");
            var client = new RestClient(options);
            var request = new RestRequest("/api/Colecao/ByFilter", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                return !string.IsNullOrEmpty(response.Content);
            }
            else
            {
                Console.WriteLine($"Erro ao verificar existência da coleção: {response.ErrorMessage}");
                throw new Exception($"Erro ao verificar existência da coleção: {response.ErrorMessage}");
            }
        }
    }
}