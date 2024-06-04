using Application.DTOs.Users.GetUser;
using Application.Services.Interfaces;
using Domain.Shared.Constants;
using Domain.Shared.Helpers;

namespace API.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers[Settings.AuthorizationRequestHeader]
                                    .FirstOrDefault()
                                    ?.Split(" ")
                                    .Last();

        var userId = JwtHelper.ValidateJwtToken(token);

        if (userId != null)
        {
            var request = new GetUserRequest { Id = userId.Value };
            var userResponse = await userService.GetAsync(request);

            if (userResponse.IsSuccess)
            {
                context.Items[Settings.CurrentUserContextKey] = userResponse.Data;
            }
        }

        await _next(context);
    }

}