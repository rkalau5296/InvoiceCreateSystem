namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PostUserHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostUserRequest, PostUserResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
    {
        var user = this.mapper.Map<DataAccess.Entities.User>(request);
        var command = new PostUserCommand() { Parametr = user };
        var userFromDb = await commandExecutor.Execute(command);
        return new PostUserResponse()
        {
            Data = this.mapper.Map<Domain.Models.User>(userFromDb)
        };
    }
}
