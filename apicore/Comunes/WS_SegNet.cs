using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes
{
    public class WS_SegNet
    {
        /// <summary>
        /// Metodo que permite encriptar un valor para enviar al servicio WS_SegNet
        /// </summary>
        /// <param name="ValorAEncriptar">Valor a Encriptar</param>
        /// <returns>Valor Encriptado</returns>
        public static string EncriptarValor(string ValorAEncriptar)
        {
            return ValorAEncriptar;
        }
        /// <summary>
        /// Metodo que permite desencriptar un valor del servicio WS_SegNet
        /// </summary>
        /// <param name="ValorEncriptado">Valor a Desencriptar</param>
        /// <returns>Valor Desencriptado</returns>
        public static string DesEncriptarValor(string ValorEncriptado)
        {
            return ValorEncriptado;
        }
        
        /// <summary>
        /// Función para encriptar y desencriptar valores - Segurinet
        /// </summary>
        /// <param name="EnDec">true - Encriptar, false - Desencriptar</param>
        /// <param name="InputString">String Valor</param>
        /// <param name="OutputRaw">Resultado</param>
        /// <param name="Length">Tamaño del string destino.</param>
        /// <returns></returns>
        //[DllImport("SegCrypt_MiCreditoOrq.dll")]
        //unsafe private static extern bool EncryptDecrypt(bool EnDec, string InputString, byte* OutputRaw, int* Length);
    }
}
