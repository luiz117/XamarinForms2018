using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App2CEP.Servico.Modelo;
using Newtonsoft.Json;



namespace App2CEP.Servico
{
    public class ViaCEPServico
    {
        private static String EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL =string.Format(EnderecoURL , cep) ;

            WebClient wc = new WebClient();
            String Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null)            
                return null; 
            

            return end;                            
        }
    }
}
