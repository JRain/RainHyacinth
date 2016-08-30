namespace RainHyacinth.Inject
{
    /// <summary>
    /// 依赖注入生命周期
    /// </summary>
    public interface IInjectLifeScope : IInjectService
    {
        /// <summary>
        /// 第三方组建生命周期，为了便于第三方组建的替换，这里采用object弱类型，内部调用需要做强转
        /// </summary>
        object NonpartyLifeScope { get; }
        /// <summary>
        /// 线程Id
        /// </summary>
        int ThreadId { get; }
    }
}
