namespace RainHyacinth.Lite
{
    /// <summary>
    /// 数据模型Model接口
    /// </summary>
    public interface ICommonLite
    {
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        string GetTableName();
        /// <summary>
        /// 获取集合名称
        /// </summary>
        /// <returns></returns>
        string GetSchemaName();
    }
    /// <summary>
    /// RainHyacinth框架ORM 通用的主键规则标识接口
    /// </summary>
    public interface ICommonIdentityLite : ICommonLite
    {
        /// <summary>
        /// 主键
        /// </summary>
        string Id { get; set; }
    }
    /// <summary>
    /// RainHyacinth框架ORM 通用的业务模型接口
    /// </summary>
    public interface IBaseCommonLite : ICommonIdentityLite
    {
        /// <summary>
        /// 创建时间戳
        /// </summary>
        double CreateStamp { get; set; }
        /// <summary>
        /// 修改时间戳
        /// </summary>
        double ModifyStamp { get; set; }
        /// <summary>
        /// 删除时间戳
        /// </summary>
        double? DeleteStamp { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        int Version { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDelete { get; set; }
        /// <summary>
        /// 获取存储名称
        /// </summary>
        /// <returns></returns>
        string GetStorageName();
    }
}
