using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CondominioService.DenunciaContext.Application.Interfaces;
using CondominioService.DenunciaContext.Application.ViewModels;
using CondominioService.DenunciaContext.Domain;
using CondominioService.DenunciaContext.Domain.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using CondominioService.Core.Data.EventSourcing;
using CondominioService.Core.Communication.Mediator;
using CondominioService.DenunciaContext.Application.Events;
using CondominioService.Core.Messages.CommonMessages.Notifications;

namespace CondominioService.DenunciaContext.Application.Services
{
    public class DenunciaAppService : IDenunciaAppService
    {
        private readonly IMapper _mapper;
        private readonly IDenunciaRepository _denunciaRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public DenunciaAppService(IMapper mapper,
                                  IMediatorHandler mediatorHandler,
                                  IDenunciaRepository denunciaRepository)
        {
            this._mapper = mapper;
            this._mediatorHandler = mediatorHandler;
            this._denunciaRepository = denunciaRepository;
        }

        public void AdicionarDenuncia(CriarDenunciaViewModel criarDenunciaViewModel)
        {
            Denuncia denuncia = _mapper.Map<Denuncia>(criarDenunciaViewModel);
            _denunciaRepository.Adicionar(denuncia);
            _mediatorHandler.PublicarEvento(new DenunciaRegistradaEvent(denuncia.Id, denuncia.Descricao)).Wait();
        }

        public void AtualizarDenuncia(AtualizarDenunciaViewModel atualizarDenunciaViewModel)
        {
            Denuncia denuncia = _denunciaRepository.ObterPorId(atualizarDenunciaViewModel.Id);
            if (denuncia == null)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification("denuncia", "Denúncia não encontrada pelo Id!")).Wait();
                return;
            }

            denuncia.DefinirDescricao(atualizarDenunciaViewModel.Descricao);

            _denunciaRepository.Atualizar(denuncia);
            _mediatorHandler.PublicarEvento(new DenunciaAtualizadaEvent(denuncia.Id, denuncia.Descricao)).Wait();
        }

        public void DeletarDenuncia(Guid id)
        {
            Denuncia denuncia = _denunciaRepository.ObterPorId(id);
            _denunciaRepository.Remover(denuncia);

            _mediatorHandler.PublicarEvento(new DenunciaDeletadaEvent(id)).Wait();
        }

        public IEnumerable<DetalhesDenunciaViewModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<DetalhesDenunciaViewModel>>(_denunciaRepository.ObterTodosAtivos());
        }

        public DetalhesDenunciaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<DetalhesDenunciaViewModel>(_denunciaRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _denunciaRepository?.Dispose();
            this?.Dispose();
        }
    }
}
