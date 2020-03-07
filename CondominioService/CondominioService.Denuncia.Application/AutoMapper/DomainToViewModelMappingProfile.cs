using AutoMapper;
using CondominioService.DenunciaContext.Application.ViewModels;
using CondominioService.DenunciaContext.Domain.Models;

namespace CondominioService.DenunciaContext.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            //CreateMap<Produto, ProdutoViewModel>()
            //    .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
            //    .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
            //    .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            //CreateMap<Denuncia, DenunciaViewModel>()
            //    .ForMember(d => d.Denunciado, o => o.MapFrom(s => s.Denunciado))
            //    .ForMember(d => d.TipoDenuncia, o => o.MapFrom(s => s.TipoDenuncia));


            //CreateMap<Integration.BigBoost.Models.Address, Domain.Models.Address>()
            //    .ConstructUsing(a => new Address(a.AddressMain,
            //                                     a.Number,
            //                                     a.Complement,
            //                                     a.Neighborhood,
            //                                     a.ZipCode,
            //                                     a.City,
            //                                     a.State,
            //                                     "Big Data Corp"));

            CreateMap<Denuncia, CriarDenunciaViewModel>();
            CreateMap<Denuncia, AtualizarDenunciaViewModel>();
            CreateMap<Denuncia, DeletarDenunciaViewModel>();
            CreateMap<Denuncia, DetalhesDenunciaViewModel>();
        }
    }
}
