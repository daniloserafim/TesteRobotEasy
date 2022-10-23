using ApiCotacao.Libraries;
using ApiCotacao.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text.Json.Nodes;

namespace ApiCotacao.Controllers
{
    public class CotacaoController
    {
        //public static string GetCotacao(string moedaBase, string moedaAlvo)
        //{
            //Cotacao cotacao = new Cotacao();
            //string valor = cotacao.GetEntry(moedaBase, moedaAlvo);
            //if (valor != null)
            //{
            //    return valor;
            //}

            //CotacaoUseCases useCase = new CotacaoUseCases();

            //valor = useCase.GetCotacaoSelenium(moedaBase, moedaAlvo);

            //try
            //{
            //    cotacao.Insert(moedaBase, moedaAlvo, valor);
            //} catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return BuildResponse(moedaBase, moedaAlvo, valor);
        //}

        public static string BuildResponse(string moedaBase, string moedaAlvo, string valor)
        {
            CotacaoResponse response = new CotacaoResponse();

            response.moedaBase = moedaBase;
            response.moedaAlvo = moedaAlvo;
            response.data = new DateTime();
            response.valor = valor;

            return JsonConvert.SerializeObject(response);
        }
    }
}
