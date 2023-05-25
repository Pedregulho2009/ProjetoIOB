﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoIOB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IOBBDEntities : DbContext
    {
        public IOBBDEntities()
            : base("name=IOBBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTATO> CONTATO { get; set; }
        public virtual DbSet<EVENTO> EVENTO { get; set; }
    
        public virtual ObjectResult<sp_viewAllContato_Result> sp_viewAllContato()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_viewAllContato_Result>("sp_viewAllContato");
        }
    
        public virtual int sp_insertupdate_contato(Nullable<int> id, string nome, string telefone, string telefone_aux, string email, Nullable<System.DateTime> data_nascimento, Nullable<int> cep, string rua, Nullable<int> numero, string complemento, string bairro, string cidade, string estado, ObjectParameter idout)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nomeParameter = nome != null ?
                new ObjectParameter("nome", nome) :
                new ObjectParameter("nome", typeof(string));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("telefone", telefone) :
                new ObjectParameter("telefone", typeof(string));
    
            var telefone_auxParameter = telefone_aux != null ?
                new ObjectParameter("telefone_aux", telefone_aux) :
                new ObjectParameter("telefone_aux", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var data_nascimentoParameter = data_nascimento.HasValue ?
                new ObjectParameter("data_nascimento", data_nascimento) :
                new ObjectParameter("data_nascimento", typeof(System.DateTime));
    
            var cepParameter = cep.HasValue ?
                new ObjectParameter("cep", cep) :
                new ObjectParameter("cep", typeof(int));
    
            var ruaParameter = rua != null ?
                new ObjectParameter("rua", rua) :
                new ObjectParameter("rua", typeof(string));
    
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("numero", numero) :
                new ObjectParameter("numero", typeof(int));
    
            var complementoParameter = complemento != null ?
                new ObjectParameter("complemento", complemento) :
                new ObjectParameter("complemento", typeof(string));
    
            var bairroParameter = bairro != null ?
                new ObjectParameter("bairro", bairro) :
                new ObjectParameter("bairro", typeof(string));
    
            var cidadeParameter = cidade != null ?
                new ObjectParameter("cidade", cidade) :
                new ObjectParameter("cidade", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertupdate_contato", idParameter, nomeParameter, telefoneParameter, telefone_auxParameter, emailParameter, data_nascimentoParameter, cepParameter, ruaParameter, numeroParameter, complementoParameter, bairroParameter, cidadeParameter, estadoParameter, idout);
        }
    
        public virtual ObjectResult<sp_viewContatoById_Result> sp_viewContatoById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_viewContatoById_Result>("sp_viewContatoById", idParameter);
        }
    
        public virtual int sp_deleteContato(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteContato", idParameter);
        }
    
        public virtual int sp_deleteEvento(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteEvento", idParameter);
        }
    
        public virtual int sp_insertupdate_evento(Nullable<int> id, string nome, Nullable<System.DateTime> data, string descricao, ObjectParameter idout)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nomeParameter = nome != null ?
                new ObjectParameter("nome", nome) :
                new ObjectParameter("nome", typeof(string));
    
            var dataParameter = data.HasValue ?
                new ObjectParameter("data", data) :
                new ObjectParameter("data", typeof(System.DateTime));
    
            var descricaoParameter = descricao != null ?
                new ObjectParameter("descricao", descricao) :
                new ObjectParameter("descricao", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertupdate_evento", idParameter, nomeParameter, dataParameter, descricaoParameter, idout);
        }
    
        public virtual ObjectResult<sp_viewAllEvento_Result> sp_viewAllEvento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_viewAllEvento_Result>("sp_viewAllEvento");
        }
    
        public virtual ObjectResult<sp_viewEventoById_Result> sp_viewEventoById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_viewEventoById_Result>("sp_viewEventoById", idParameter);
        }
    }
}