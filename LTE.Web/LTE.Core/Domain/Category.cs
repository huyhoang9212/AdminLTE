﻿

namespace LTE.Core.Domain
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
