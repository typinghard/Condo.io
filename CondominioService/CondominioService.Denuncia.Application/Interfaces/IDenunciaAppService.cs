using CondominioService.DenunciaContext.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominioService.DenunciaContext.Application.Interfaces
{
    public interface IDenunciaAppService
    {
        IEnumerable<DetalhesDenunciaViewModel> ObterTodas();
        DetalhesDenunciaViewModel ObterPorId(Guid id);

        void AdicionarDenuncia(CriarDenunciaViewModel denunciaViewModel);

        void AtualizarDenuncia(AtualizarDenunciaViewModel denunciaViewModel);

        void DeletarDenuncia(Guid id);
    }
}
