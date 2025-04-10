using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Transversal.Common
{
    public static class Message
    {
        public const string UnexpectedError = "Ocurrió un error en el sistema, contacte con sistemas con el siguiente código: {0}";
        public const string DidNotFindAnyResults = "No se encontraron resultados";
        public const string GenericErrorMessage = "Ocurrio un error y no se pudo realizar la operación solicitada";
        public const string Unauthorized = "No se encuentra autorizado para realizar esta operación.";
        public const string RegisterLogOk = "Se registró el log correctamente.";
        public const string DidntSendInformationForConsume = "No se envio la información necesaria para realizar la operación solicitada.";
    }
}
