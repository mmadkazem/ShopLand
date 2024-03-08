namespace ShopLand.Application.RequestPays.Commands.CreateRequestPay.Request;

public record CreateRequestPayCommandRequest(Guid UserId, uint Amount);