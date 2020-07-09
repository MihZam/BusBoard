using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      var dr = new DataReceiver();
      foreach (var bus in dr.processRequest("490008660N"))
      {
        Console.WriteLine(bus.lineName);
      }
    }
  }
}
