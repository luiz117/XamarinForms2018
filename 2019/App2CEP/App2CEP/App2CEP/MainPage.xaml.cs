using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App2CEP.Servico.Modelo;
using App2CEP.Servico;


namespace App2CEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            
            //TODO  - VALIDAÇÕES
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {0} , Bairro: {1} , Cidade: {2} , Estado: {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "o ENDEREÇO NÃO FOI ENCONTRADO PARA O CEP INFORMADO: " +cep, "OK" );
                    }
                        
                }
                catch(Exception ex) 
                {
                    DisplayAlert("ERRO CRITICO", ex.Message, "OK");
                }


            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO. O CEP DEVE CONTER 8 CARACTERES", "OK");

                valido = false;
            }

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO. O CEP DEVE CONTER SOMENTE NÚMEROS", "OK");

                valido = false;
            }

            return valido;
        }

    }
}
