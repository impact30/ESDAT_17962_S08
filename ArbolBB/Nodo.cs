using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBusBin{
    class Nodo{
        public Nodo Izq { get; set; }
        public Nodo Der { get; set; }
        public int Dato { get; set; }

        public Nodo(int dato) {
            Dato = dato;
        }

        public Nodo() {
        }
    }
}
