using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using Dados;

namespace MyNamespace
{
    class DesafioAPI
    {
        static async Task Main(string[] args)//main de forma assincrona com task
        {
            string Cep;
            var comparar = "[0-9]{8}";

            Console.WriteLine("Qual cep deseja? escrever dessa forma: xxxxxxxx");
            Cep = Console.ReadLine();

            Match resultado = Regex.Match(Cep, comparar);

            if (resultado.Success)
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/") };//endereço base que vamos acessar
                //await == espera o aguardavel
                //DeserializeObject == QUEBRAR JSON
                //SerializeObject == TRASFORMAR JSON EM TEXTO
                var response = await client.GetAsync($"{Cep}/json/");//acessar a api na rota do endereço web TODO:JUNTAR NA NA URI MAIS FACIL DEBUGAR
                var content = await response.Content.ReadAsStringAsync();//retornar os dados da api em texto de forma assincrona 
                var dados = JsonConvert.DeserializeObject<DadosCep>(content);//transformar os dados da api em object
                
                dados.imprimirDados();

                return;
            }
            Console.WriteLine("Cep invalido");
        }
    }
}


