using InvoiceCreateSystem.ApplicationServices.Mail;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using MediatR;
using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;    
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;    
public class PostAddressHandler(ICommandExecutor commandExecutor, IMapper mapper, IEmailSender emailSender) : IRequestHandler<PostAddressRequest, PostAddressResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;
    private readonly IEmailSender emailSender = emailSender;

    public async Task<PostAddressResponse> Handle(PostAddressRequest request, CancellationToken cancellationToken)
    {            
        var command = new PostAddressCommand() { Parametr = request.Address };
        var addressFromDb = await commandExecutor.Execute(command);
        await emailSender.SendProductCreatedEmailAsync(request.Address.Email, request.Address.Street);
        return new PostAddressResponse()
        {
            Data = this.mapper.Map<Domain.Models.Address>(addressFromDb)
        };
    }
}
