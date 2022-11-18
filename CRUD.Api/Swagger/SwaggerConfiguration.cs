namespace CRUD.Api.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Login para acessar página do Swagger.
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Senha para acessar página do Swagger.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Nome base do assembly para carregar o XML.
        /// </summary>
        public string AssembliesBasePath { get; set; } = string.Empty;

        /// <summary>
        /// Versão da API.
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        /// Nome que aparece no ínicio da página do Swagger.
        /// </summary>
        public string PageDisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Nome que aparece como contato na página do Swagger.
        /// </summary>
        public string PageContactName { get; set; } = string.Empty;
    }
}
