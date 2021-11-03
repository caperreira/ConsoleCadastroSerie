using CRUDStreaming.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDStreaming.Class
{
    // Esta sendo implementado um interface de Streaming ///
    class StreamingRepository : Repository<Streaming>
    {
        // Variavel de que esta instanciando uma lista ///
        private List<Streaming> listStreaming = new List<Streaming>();

        public void Atualiza(int id, Streaming objeto)
        {
            listStreaming[id] = objeto;
        }

        public void Exclui(int id)
        {
            listStreaming[id].Excluir(); 
        }

        public void Insere(Streaming objeto)
        {
            listStreaming.Add(objeto);
        }

        public List<Streaming> Lista()
        {
            return listStreaming; 
            
        }

        public int ProximoId()
        {
            return listStreaming.Count;
        }

        public Streaming RetornaPorId(int id)
        {
            return listStreaming[id];
        }
    }
}
