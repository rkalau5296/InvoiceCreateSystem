namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PutUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutUserRequest, PutUserResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;    

    public async Task<PutUserResponse> Handle(PutUserRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<DataAccess.Entities.User>(request.User);

        user.Id = request.Id;

        var command = new PutUserCommand { Parametr = user };
        var updatedUser = await commandExecutor.Execute(command);

        //var domainMethodOfPayment = mapper.Map<Domain.Models.MethodOfPayment>(updatedMethodOfPayment);

        return new PutUserResponse { Data = updatedUser };
    }
}
