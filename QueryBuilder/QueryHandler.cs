using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QueryBuilder
{
    public class QueryHandler
    {
        //Propiedades.
        public string Index { get; set; }
        public string SrcIp { get; set; }
        public string DestIp { get; set; }
        public string DestPort { get; set; }

        //Listas par uso interno.
        readonly List<string> _index = new List<string>();
        readonly List<string> _src = new List<string>();
        readonly List<string> _dip = new List<string>();
        readonly List<string> _dport = new List<string>();

        //Metodos.

        public void AddIndex(string newValue)
        {

            //Borro lo que tenia antes
            Index = "";
            //Primero lo agrego a la lista.
            _index.Add(newValue);

            //Actualizar mi indice.
            if (_index.Count > 1)
            {
                int i = 0;
                Index = "index IN (";
                foreach(string parameter in _index)
                {
                    if(i==0)
                        Index += $"{parameter}";
                    else
                        Index += $", {parameter}";
                    i++;
                }
                Index += ")";
            }
            else
            {
                Index = $" index = {newValue}";
            }
        }

        public void ResetIndex()
        {
            _index.Clear();
            Index = "";
            SrcIp = "";
            DestIp = "";
            DestPort = "";
        }

        public void AddSrcIp(string newValue)
        {

            //Borro lo que tenia antes
            SrcIp = "";
            //Primero lo agrego a la lista.
            _src.Add(newValue);

            //Actualizar mi indice.
            if (_src.Count > 1)
            {
                int i = 0;
                SrcIp = " src_ip IN (";
                foreach (string parameter in _src)
                {
                    if (i == 0)
                        SrcIp += $"{parameter}";
                    else
                        SrcIp += $", {parameter}";
                    i++;
                }
                SrcIp += ")";
            }
            else
            {
                SrcIp = $" src_ip = {newValue}";
            }
        }

        public void AddDestIp(string newValue)
        {

            //Borro lo que tenia antes
            DestIp = "";
            //Primero lo agrego a la lista.
            _dip.Add(newValue);

            //Actualizar mi indice.
            if (_dip.Count > 1)
            {
                int i = 0;
                DestIp = " dest_ip IN (";
                foreach (string parameter in _dip)
                {
                    if (i == 0)
                        DestIp += $"{parameter}";
                    else
                        DestIp += $", {parameter}";
                    i++;
                }
                DestIp += ")";
            }
            else
            {
                DestIp = $" dest_ip = {newValue}";
            }
        }

        public void AddDestPort(string newValue)
        {

            //Borro lo que tenia antes
            DestPort = "";
            //Primero lo agrego a la lista.
            _dport.Add(newValue);

            //Actualizar mi indice.
            if (_dport.Count > 1)
            {
                int i = 0;
                DestPort = " dest_port IN (";
                foreach (string parameter in _dport)
                {
                    if (i == 0)
                        DestPort += $"{parameter}";
                    else
                        DestPort += $", {parameter}";
                    i++;
                }
                DestPort += ")";
            }
            else
            {
                DestPort = $" dest_ip = {newValue}";
            }
        }

        public void DelIndex(string existingValue)
        { 
            _index.Remove(existingValue);
            //Actualizar mi indice.
            if (_index.Count > 1)
            {
                int i = 0;
                Index = "index IN (";
                foreach (string parameter in _index)
                {
                    if (i == 0)
                        Index += $"{parameter}";
                    else
                        Index += $", {parameter}";
                    i++;
                }
                Index += ")";
            }
            else if (_index.Count==1)
            {
                Index = $" index = {_index[0]}";
            }
            else
            {
                Index = "";
            }
        }

        public void DelSrcIp(string existingValue)
        {
            _src.Remove(existingValue);
            if (_src.Count > 1)
            {
                int i = 0;
                SrcIp = " src_ip IN (";
                foreach (string parameter in _src)
                {
                    if (i == 0)
                        SrcIp += $"{parameter}";
                    else
                        SrcIp += $", {parameter}";
                    i++;
                }
                SrcIp += ")";
            }
            else if (_index.Count == 1)
            {
                SrcIp = $" src_ip = {_src[0]}";
            }

            else SrcIp = "";
        }

        public void DelDestIp(string existingValue)
        {
            //Primero lo agrego a la lista.
            _dip.Remove(existingValue);

            //Actualizar mi indice.
            if (_dip.Count > 1)
            {
                int i = 0;
                DestIp = " dest_ip IN (";
                foreach (string parameter in _dip)
                {
                    if (i == 0)
                        DestIp += $"{parameter}";
                    else
                        DestIp += $", {parameter}";
                    i++;
                }
                DestIp += ")";
            }
            else if (_index.Count == 1)
            {
                DestIp = $" dest_ip = {_dip[0]}";
            }

            else
            {
                DestIp = "";
            }
    }

        public void DelDestPort (string existingValue)
        {
            //Primero lo agrego a la lista.
            _dport.Remove(existingValue);

            //Actualizar mi indice.
            if (_dport.Count > 1)
            {
                int i = 0;
                DestPort = " dest_port IN (";
                foreach (string parameter in _dport)
                {
                    if (i == 0)
                        DestPort += $"{parameter}";
                    else
                        DestPort += $", {parameter}";
                    i++;
                }
                DestPort += ")";
            }
            else if (_index.Count == 1)
            {
                DestPort = $" dest_port = {_dport[0]}";
            }

            else
            {
                DestPort ="";

            }
        }


       
    }

    }
    
