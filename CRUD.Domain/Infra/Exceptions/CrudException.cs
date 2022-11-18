using System.Net;

namespace CRUD.Domain.Infra.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class CrudException : Exception
    {
        /// <summary>
        /// Codigo de retorno.
        /// </summary>
        public HttpStatusCode? CodResponse { get; private set; } = HttpStatusCode.BadRequest;

        /// <summary>
        /// Detalhes da exceção.
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Recuperável?
        /// </summary>
        public bool Recoverable { get; private set; } = false;

        /// <summary>
        /// Exceção simples com mensagem.
        /// </summary>
        public CrudException()
            : this(message: "Ocorreu um erro inesperado ao processar a sua solicitação.") { }

        /// <summary>
        /// Exceção simples com uma mensagem personalizada e também com a mensagem da exceção.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CrudException(string message, Exception? innerException = null)
            : this(message, details: string.Empty, innerException) { }

        /// <summary>
        /// Exceção personalizada com a mensagem, o código e a innerException
        /// </summary>
        public CrudException(string message, HttpStatusCode codResponse, Exception? innerException = null)
            : this(message, codResponse, details: string.Empty, innerException) { }

        /// <summary>
        /// Exceção personalizada com a mensagem, o código, os detalhes e a innerException
        /// </summary>
        public CrudException(string message, HttpStatusCode codResponse, string details, Exception? innerException = null)
            : this(message, codResponse, recoverable: false, details, innerException) { }

        /// <summary>
        /// Exceção personalizada com a mensagem, se será recuperavel e a innerException
        /// </summary>
        public CrudException(string message, bool recoverable, Exception? innerException = null)
            : this(message, recoverable, string.Empty, innerException) { }

        /// <summary>
        /// Exceção personalizada com a mensagem, se será recuperavel, os detalhes e a innerException
        /// </summary>
        public CrudException(string message, bool recoverable, string details, Exception? innerException = null)
            : this(message, codResponse: HttpStatusCode.BadRequest, recoverable, details, innerException) { }

        /// <summary>
        /// Exceção personalizada com a mensagem, o código, se será recuperavel, os detalhes e a innerException
        /// </summary>
        public CrudException(string message, HttpStatusCode codResponse, bool recoverable, string details, Exception? innerException = null)
            : this(message, details, innerException)
        {
            CodResponse = codResponse;
            Recoverable = recoverable;
        }

        /// <summary>
        /// Exceção personalizada com a mensagem, os detalhes e a innerException
        /// </summary>
        public CrudException(string message, string details, Exception? innerException = null)
          : base(message ?? "Ocorreu um erro inesperado ao processar a sua solicitação.", innerException) => Details = details;
    }
}
