using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.DataBaseSeeder.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Test.Core.Seeders.Localities
{
    public class StateSeeder : IDatabaseSeed<Context>
    {
        public int Ordem => 10;

        public int TotalItems => 1;

        public async Task Run(Context context)
        {
            #region script para criar estados
            await context.Database.ExecuteSqlRawAsync(InsertStates);
            #endregion
        }

        private readonly string InsertStates = @"          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('AC', 'Acre', 1, GETDATE(), GETDATE(), 0);           
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('AL', 'Alagoas', 1, GETDATE(), GETDATE(), 0);        
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('AP', 'Amapá', 1, GETDATE(), GETDATE(), 0);          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('AM', 'Amazonas', 1, GETDATE(), GETDATE(), 0);       
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('BA', 'Bahia', 1, GETDATE(), GETDATE(), 0);          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('CE', 'Ceará', 1, GETDATE(), GETDATE(), 0);          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('DF', 'Distrito Federal', 1, GETDATE(), GETDATE(), 0);
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('ES', 'Espírito Santo', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('GO', 'Goiás', 1, GETDATE(), GETDATE(), 0);          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('MA', 'Maranhão', 1, GETDATE(), GETDATE(), 0);       
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('MT', 'Mato Grosso', 1, GETDATE(), GETDATE(), 0);    
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('MS', 'Mato Grosso do Sul', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('MG', 'Minas Gerais', 1, GETDATE(), GETDATE(), 0);   
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('PA', 'Pará', 1, GETDATE(), GETDATE(), 0);           
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('PB','Paraíba', 1, GETDATE(), GETDATE(), 0);         
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('PR', 'Paraná', 1, GETDATE(), GETDATE(), 0);         
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('PE', 'Pernambuco', 1, GETDATE(), GETDATE(), 0);     
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('PI', 'Piauí', 1, GETDATE(), GETDATE(), 0);          
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('RJ', 'Rio de Janeiro', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('RN', 'Rio Grande do Norte', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('RS', 'Rio Grande do Sul', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('RO', 'Rondônia', 1, GETDATE(), GETDATE(), 0);       
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('RR', 'Roraima', 1, GETDATE(), GETDATE(), 0);        
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('SC', 'Santa Catarina', 1, GETDATE(), GETDATE(), 0); 
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('SP', 'São Paulo', 1, GETDATE(), GETDATE(), 0);      
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('SE', 'Sergipe', 1, GETDATE(), GETDATE(), 0);        
                Insert into Localities.State (Uf, Name, Activated, UpdatedAt, CreatedAt, Deleted) values('TO', 'Tocantins', 1, GETDATE(), GETDATE(), 0);
            ";
    }
}
