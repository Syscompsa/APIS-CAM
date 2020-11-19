using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.InventoryApp
{
    public class ALPTABLA
    {
      public int Id             {get; set;}
      public char Master        {get; set;}
      public char Codigo        {get; set;}
      public string Nombre      {get; set;}
      public decimal Valor      {get; set;}
      public char Nomtag        {get; set;}
      public char Gestion       {get; set;}
      public bool Pideval       {get; set;}
      public string Campo1      {get; set;}
      public string Grupo       {get; set;}
      public char Sgrupo        {get; set;}
      public string Campo2      {get; set;}
      public decimal Lencod     {get; set;}
      public decimal VALOR2     {get; set;}
      public Boolean FLAG_VALUE {get; set;}

    }               
}
