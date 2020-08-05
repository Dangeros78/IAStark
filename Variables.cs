using System;
using System.Collections;
using System.IO.Ports;

namespace STARK
{
    public class Variables
    {
        public ArrayList listaComandos = new ArrayList();
        public string[] comandos;
        public string[] confirmarcmd;
        public string[] multiejecutar;
        public string[] multirespuesta;
        public string palabraresultcmd;
        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataReader readerS;
        public DateTime fecha;
        public Random random = new Random();
        public bool cmdConfirmado;
        public string palabraresultante;
        public string cadenaBD;
        public string textToSpeak;
        public SerialPort serial_escucha;
    }
}
