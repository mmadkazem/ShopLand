namespace ShopLand.Application.RequestPays.Services;


public interface IPayOffService
{
    (string Authority, long RefId) PayOff();
}