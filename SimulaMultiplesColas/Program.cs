using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaServidor {
    struct Cajero {
        public bool Ocupado;
		public long TipoCliente;
		public int Tiempo_Restante;
    };

    class Program {
        static void Main(string[] args) {
			char runAgain='S';
			while (runAgain != 'N') {
				int sim_Time, trans_Time, num_Serv, arriv_Time, arriv_Time_Dis;
				int i = 0, c_Time = 0; //Counters
				int customers = 0, atendidos=0, atendidosDis=0, left, wait_Time = 0;
				

				Console.Write( "\n------------------------------------------"
					 + "\n- Bienvenido al la Simulacion de banco -"
					 + "\n------------------------------------------");

				//Menu information
				Console.Write( "\n\nIngrese los siguentes datos en minutos:\n");
				Console.Write( "\nTiempo de la simulación: " );
				sim_Time = Convert.ToInt32( Console.ReadLine()) ;
				Console.Write( "Tiempo de atención del servidor: ");
				trans_Time = Convert.ToInt32(Console.ReadLine( ));
				Console.Write( "Cantidad de servidores: ");
				num_Serv = Convert.ToInt32(Console.ReadLine( ));
				/*
				Console.Write( "Tiempo entre llegada de Discapacitados: ");
				arriv_Time_Dis = Convert.ToInt32(Console.ReadLine( ));
				*/
				Console.Write("Tiempo entre llegada de Clientes: ");
				arriv_Time = Convert.ToInt32(Console.ReadLine());

				Cajero[] tellArray = new Cajero[num_Serv];
                Cola[] bankQ = new Cola[num_Serv];

                //Set all tellers to empty
                for (i = 0; i < num_Serv; i++) {
					tellArray[i].Ocupado = false;
					tellArray[i].TipoCliente = 0;
					tellArray[i].Tiempo_Restante = 0;
					bankQ[i] = new Cola();
                }

				while (c_Time < sim_Time) {

					//PASO 1: Cada cliente que llega se va a la cola
					if (c_Time % arriv_Time == 0) {
						//calc ind con menor cantidad de personas o cero
						int colaMenPer = 0;
						if (bankQ[colaMenPer].GetSize() == 0) {
							bankQ[colaMenPer].Enqueue();
							customers++;
						} else {

							for (i = 1; i < num_Serv; i++) {
								if (bankQ[i].GetSize() < bankQ[colaMenPer].GetSize()) {
									colaMenPer = i;
                                    if (bankQ[colaMenPer].GetSize() == 0) {
										break;
                                    }
                                }
                            }
                            bankQ[colaMenPer].Enqueue();
                            customers++;
                        }
                        
					}

					//PASO2: Busca que servidor esta disponible para asignarle un cliente
					for (i = 0; i < num_Serv; i++) {
						if (bankQ[i].GetSize() > 0) {
							if (tellArray[i].Ocupado == false) {
								tellArray[i].TipoCliente = bankQ[i].Dequeue();
								tellArray[i].Ocupado = true;
								tellArray[i].Tiempo_Restante = trans_Time;
							}
						}
					}
					

					//PASO 3: resta el tiempo restante al servidor. Si este llega a cero lo pone disponible
					for (i = 0; i < num_Serv; i++) {
						if (tellArray[i].Ocupado == true) {
							tellArray[i].Tiempo_Restante--;
						}
						if (tellArray[i].Tiempo_Restante == 0 && tellArray[i].Ocupado == true) {

							if (tellArray[i].TipoCliente == 1) {
								atendidos++;
							}
							tellArray[i].TipoCliente = 0;
							tellArray[i].Ocupado = false;
						}
					}

					int cant1 = bankQ[0].GetSizeN();
                    int cant2 = bankQ[1].GetSizeN();
                    int cant3 = bankQ[2].GetSizeN();
                    //s2:{tellArray[1].Ocupado}  s3:{tellArray[2].Ocupado} 
                    Console.Write( $"\n{c_Time}-- en colas :{cant1} - {cant2} - {cant3} | s1:{tellArray[0].Ocupado} s2:{tellArray[1].Ocupado} s3:{tellArray[2].Ocupado} | atn N:{atendidos}");
					wait_Time += 0;
					c_Time++;
				}

				Console.Write( "\n---------------"
					 + "\n- REPORTE -"
					 + "\n---------------\n");


				Console.Write( "Tiempo promedio de espera: ");

				Console.Write( "" +  ( (float) wait_Time / customers) );
				Console.WriteLine( wait_Time );

				Console.Write( "\n\nEjecutar programa otra vez? (s/n): ");
				runAgain =Convert.ToChar( Console.ReadLine( ));
				runAgain = char.ToUpper(runAgain);
				while (runAgain != 'S' && runAgain != 'N') {
					Console.Write("Letra inválida. Ejecutar programa otra vez? (s/n): ");
					runAgain = Convert.ToChar(Console.ReadLine());
					runAgain = char.ToUpper(runAgain);
				}
			}
		}
    }
}
