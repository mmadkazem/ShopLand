namespace ShopLand.Application.RequestPays.Queries.Response;

public record GetRequestPayQueryResponse
(
    Guid UserId, uint Amount,
    DateTime? PayDate, bool IsPay
) : IResponse;

public static class Exceptions
{
    public static GetRequestPayQueryResponse AsResponse(this RequestPay requestPay)
        => new(requestPay.UserId, requestPay.Amount, requestPay.PayDate, requestPay.IsPay);
}