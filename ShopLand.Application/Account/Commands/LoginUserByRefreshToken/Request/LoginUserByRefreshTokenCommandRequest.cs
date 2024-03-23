namespace ShopLand.Application.Account.Commands.LoginUserByRefreshToken.Request;


public record LoginUserByRefreshTokenCommandRequest
(Guid UserId, string RefreshTokenSerial);
