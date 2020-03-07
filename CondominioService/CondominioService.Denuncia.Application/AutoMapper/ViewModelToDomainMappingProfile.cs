using AutoMapper;
using CondominioService.DenunciaContext.Application.ViewModels;
using CondominioService.DenunciaContext.Domain.Models;

namespace CondominioService.DenunciaContext.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // CreateMap<DenunciaViewModel, Denuncia>()
            //.ConstructUsing(c => new Denuncia(c.Id, c.Descricao));

            CreateMap<CriarDenunciaViewModel, Denuncia>();

            CreateMap<AtualizarDenunciaViewModel, Denuncia>()
                .ConstructUsing(c => new Denuncia(c.Descricao));

            CreateMap<DeletarDenunciaViewModel, Denuncia>();
            CreateMap<DetalhesDenunciaViewModel, Denuncia>();
        }
    }
}
