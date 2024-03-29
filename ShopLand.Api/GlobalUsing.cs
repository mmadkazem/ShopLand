global using ShopLand.Application;
global using ShopLand.Infrastructure;
global using Microsoft.AspNetCore.Mvc;
global using ShopLand.Application.Account.Commands.RegisterUser.Request;
global using ShopLand.Application.Users.Facade;
global using ShopLand.Share;
global using ShopLand.Api;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Authorization;
global using ShopLand.Application.Account.Queries.LoginUser.Request;
global using ShopLand.Application.Account.Commands.AddUserRole.Request;
global using System.Text;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Security.Claims;
global using ShopLand.Application.Account.Commands.ChangePassword.Request;
global using ShopLand.Application.Account.Commands.CreateRole.Request;
global using ShopLand.Application.Account.DTOs;
global using ShopLand.Application.Account.Commands.RemoveRole.Request;
global using ShopLand.Api.Common;
global using ShopLand.Application.Account.Commands.RemoveUserRole.Request;
global using ShopLand.Application.Products.Facade;
global using ShopLand.Application.Products.Commands.CreateProduct.Request;
global using ShopLand.Application.Products.Queries.GetProduct.Request;
global using ShopLand.Application.Common;
global using ShopLand.Application.Products.Commands.AddProductCategory.Request;
global using ShopLand.Application.Products.Commands.RemoveProduct.Request;
global using ShopLand.Application.Categories.Commands.CreateCategory.Request;
global using ShopLand.Application.Categories.Commands.RemoveCategory.Request;
global using ShopLand.Application.Categories.Commands.UpdateCategory.Request;
global using ShopLand.Application.Categories.Facade;
global using ShopLand.Application.Categories.Queries.GetCategory.Request;
global using ShopLand.Application.Products.Commands.RemoveProductCategory.Request;
global using ShopLand.Application.Products.Commands.UpdateProduct.Request;
global using ShopLand.Application.Products.Commands.UpdateProductCategory.Request;
global using ShopLand.Application.Carts.Commands.AddCartItem.Request;
global using ShopLand.Application.Carts.Commands.RemoveCartItem.Request;
global using ShopLand.Application.Carts.Commands.UpdateCartItem.Request;
global using ShopLand.Application.Carts.Facade;
global using ShopLand.Application.Orders.Commands.CreateOrder.Request;
global using ShopLand.Application.Orders.Commands.UpdateOrderState.Request;
global using ShopLand.Application.Orders.Facade;
global using ShopLand.Application.Orders.Queries.GetOrderByUserId.Request;
global using ShopLand.Application.RequestPays.Commands.CreateRequestPay.Request;
global using ShopLand.Application.RequestPays.Facade;
global using ShopLand.Application.RequestPays.Queries.GetRequestPay.Request;
global using ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Request;
global using Microsoft.IdentityModel.JsonWebTokens;
global using ShopLand.Application.Account.Commands.UserLogout.Request;
global using ShopLand.Infrastructure.Services.JwtToken;
global using ShopLand.Api.ApiExtensionConf;
