using FluentValidation;
using Log.Application.DTOs;

namespace Log.Transversal.Validator
{
    public class LogValidator : AbstractValidator<LogDto>
    {
        public LogValidator()
        {
            RuleFor(x => x.MachineName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se ha ingresado el hostname");

            RuleFor(x => x.Logged)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se ha indicado la fecha del loggeo");

            RuleFor(x => x.Message)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se el mensaje del log");

            RuleFor(x => x.Logger)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se ha indicado quien graba el log");

            RuleFor(x => x.ApplicationId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("No se ha indicado a que aplicación pertenece el log");
        }
    }
}
