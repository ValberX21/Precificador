using Precificador.Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precificador.Application.APIsExternas
{
    public class CallFunctions
    {
        public async Task<bool> GeraArquivoNovoMaterial<TModel>(TModel model) where TModel : ModelBase
        {
            using var client = new HttpClient();

            try
            {
                var url = "http://localhost:7056/api/Test";

                var content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(model),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(url, content);

                var responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: " + responseText);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

    }
}
