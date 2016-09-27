

using System;
using System.ComponentModel.DataAnnotations.Schema;
using LTE.Core.Infrastructure;
namespace LTE.Core
{
    public abstract class BaseEntity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
