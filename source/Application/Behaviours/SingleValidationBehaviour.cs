//using Application.Exceptions;
//using FluentValidation;
//using MediatR;
//using System.ComponentModel.DataAnnotations;
//using ValidationException = Application.Exceptions.SingleValidationException;

//namespace Application.Behaviours
//{
//    public class SingleValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : notnull
//    {
//        private readonly IValidator<TRequest> _validator;

//        public SingleValidationBehaviour(IValidator<TRequest> validator)
//        {
//            _validator = validator;
//        }

//        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            if (_validator!=null)
//            {
//                var context = new ValidationContext<TRequest>(request);

//                var validationResult = await _validator.ValidateAsync(context, cancellationToken);

//                if (validationResult != null && validationResult.Errors.Any())
//                {
//                    var failure = validationResult.Errors.FirstOrDefault();

//                    if (failure != null)
//                        throw new SingleValidationException(failure);
//                }
//            }
//            return await next();
//        }
//    }
//}