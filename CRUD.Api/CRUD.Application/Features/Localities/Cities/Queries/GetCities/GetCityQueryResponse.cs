namespace CRUD.Application.Features.Localities.Cities.Queries.GetCities
{
    /// <summary>
    /// Objeto para recuperar cidades
    /// </summary>
    public class GetCityQueryResponse
    {
        /// <summary>
        /// Identificador da cidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Uf do estado
        /// </summary>
        public string UF { get; set; } = string.Empty;

        /// <summary>
        /// Estado da entidade
        /// </summary>
        public bool Activated { get; set; }
    }
}
