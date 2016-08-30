using System;
using System.Data.Entity.ModelConfiguration;

namespace RainHyacinth.Lite.Imp
{
    /// <summary>
    /// ORM Lite 映射机制,实现该抽象类的子类还需要继承IRainLiteMap约定接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RainLiteMap<T> : EntityTypeConfiguration<T> where T : RainLite
    {
        protected RainLiteMap()
        {
            Init();
        }
        protected Type GenericType => typeof(T);

        public virtual void Init()
        {
            ToTable(TableName(), SchemaName());
            HasKey(p => p.Id);
        }

        public virtual string TableName()
        {
            return GenericType.FullName.Substring(GenericType.FullName.LastIndexOf('.') + 1);
        }

        public virtual string SchemaName()
        {
            return "dbo";
        }
    }
}
