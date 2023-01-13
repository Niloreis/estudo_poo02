using Newtonsoft.Json;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace ProjetoAula02.Repository
{   // gravação de dados do funcionario //
    public class FuncionarioRepository
    {
        //dados em Json//
        public void ExportarJson( Funcionario funcionario)
        {
          var json= JsonConvert.SerializeObject(funcionario,Formatting.Indented );
            //abrindo um arquivo gravdo//
            using(var SteamWriter=new StreamWriter($"c:\\temp\\funcionario_{funcionario.Id}.Json"))
            {
                SteamWriter.WriteLine(json);

            }
        }
        //dadosem Xml//
        public void ExportarXml(Funcionario funcionario)
        {
            var xml =  new XmlSerializer(typeof(Funcionario));
            using (var  streamWriter = new StreamWriter($"c:\\temp\\funcionario_{funcionario.Id}.Xml"))
            {
                xml.Serialize(streamWriter, funcionario);

            }
        }
       
       


    }

}
