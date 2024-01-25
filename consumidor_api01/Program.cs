// See https://aka.ms/new-console-template for more information
using consumidor_api01;
using Flurl;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string url = "https://localhost:7129/";

#region "Objetos"
Item tarefa1 = new Item();
tarefa1.ID = 1;
tarefa1.Nome = "Pagar a conta";
tarefa1.Finalizado = true;

Item tarefa2 = new Item();
tarefa2.ID = 3;
tarefa2.Nome = "Lavar louças xxx";
tarefa2.Finalizado = false;
#endregion

//gerar uma tarefa
string endpoint = url + "api/TarefaItems";

#region "Post e Listar"
Console.WriteLine("Vamos incluir");

//Post (incluir)
await endpoint.PostJsonAsync(tarefa1);
await endpoint.PostJsonAsync(tarefa2);

//ler a lista
IEnumerable<Item> listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();
foreach (var item in listaTarefas)
    {
        Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
    }
#endregion

#region "Alterar e Listar"
Console.WriteLine("Vamos alterar, digite um ID");

//alterar
int id = Convert.ToInt32(Console.ReadLine());
string endpointalt = url + $"api/TarefaItems/{id}";

Item tarefa3 = new Item();
tarefa3.ID = 1;
tarefa3.Nome = "Receber salário";
tarefa3.Finalizado = false;

await endpointalt.PutJsonAsync(tarefa3);
//ler a lista
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}
#endregion

Console.WriteLine("Vamos deletar");
//deletar um item da lista
string endpointdel = url + $"api/TarefaItems/3";
await endpointdel.DeleteAsync();

//ler a lista
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}

Console.WriteLine("Aperte qualquer tecla para finalizar...");
Console.Read();