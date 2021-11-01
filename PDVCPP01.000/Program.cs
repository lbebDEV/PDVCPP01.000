using PDVCPP01._000.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
#if (DEBUG)
            Main main = new Main();
            main.ExecucaoServico();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new GuardianPortalServicePedidos()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
