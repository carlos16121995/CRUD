namespace CRUD.Application.Features.Localities.States.Queries.GetState
{
    /// <summary>
    /// Objeto para recueprar estado
    /// </summary>
    public class GetStateQueryResponse
    {
        /// <summary>
        /// Uf do estado
        /// </summary>
        public string UF { get; set; } = string.Empty;

        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Estado da entidade.
        /// </summary>
        public bool? Activated { get; set; }
    }
}
