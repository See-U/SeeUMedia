using FluentValidation;

namespace SeeUMedia.Models.Login
{
    /// <summary>
    /// 用户验证
    /// </summary>
    public class LoginUserValidator : AbstractValidator<LoginInfo>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserAccount).NotEmpty().WithMessage("请输入账号");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("请输入密码");
        }
    }
}
