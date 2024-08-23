using ProofIdentity.Application.DTOs.Agendamentos;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;

namespace ProofIdentity.Application.UseCases.Agendamentos;
public class AgendamentoCreateUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAgendamentoReadRepository _readRepository;
    private readonly IAgendamentoWriteRepository _writeRepository;
    private readonly IAdminReadRepository _adminReadRepository;
    public AgendamentoCreateUseCase(IAgendamentoReadRepository readRepository, IAgendamentoWriteRepository writeRepository, IAdminReadRepository adminReadRepository, IUnitOfWork unitOfWork)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _adminReadRepository = adminReadRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handler(AgendamentoCreateDto request)
    {
        var admin = await _adminReadRepository.GetByCpf(request.AdminCpf);
        if (admin == null)
        {
            throw new ApplicationLayerException("Admin não encontrado");
        }

        var agendamento = new Agendamento(request.DataAgendamento, request.Data, admin);
        var id = await _writeRepository.AddAsync(agendamento);
        await _unitOfWork.SaveChangesAsync();

        return id;
    }
}