using System;
using RainHyacinth.Utils;

namespace RainHyacinth.Lite.Imp
{
    /// <summary>
    /// 公共的ORM基类,原生扩展
    /// </summary>
    public abstract class CommonLite : ICommonLite
    {
        protected readonly Type DeclareType;
        protected CommonLite()
        {
            DeclareType = this.GetType();
        }
        public virtual string GetTableName()
        {
            return DeclareType.FullName.Substring(DeclareType.FullName.LastIndexOf('.') + 1);
        }
        public virtual string GetSchemaName()
        {
            return "dbo";
        }
    }

    /// <summary>
    /// RainHyacinth ORM实体模型唯一标识基类
    /// </summary>
    public abstract class RainIdentityLite : CommonLite, ICommonIdentityLite
    {
        string _id;
        protected RainIdentityLite()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }

        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
    /// <summary>
    /// RainHyacinth ORM业务实体基类
    /// </summary>
    public abstract class RainLite : RainIdentityLite, IBaseCommonLite
    {
        private double? _createStamp;
        private double? _modifyStamp;
        private double? _deleteStamp;
        private int _version;
        private int _nowVersion;

        private int? _createTimeModifyTime;

        public int Version
        {
            get { return _version; }
            set
            {
                if (_nowVersion == 0)
                {
                    _version = value;
                    _nowVersion = _version;
                }
                else
                {
                    //一次只能改一次版本
                    if (value < 0 || value > _nowVersion + 1)
                    {
                        throw new RainHyacinthException(LiteErrorCode.SetEntityVersionError, "版本号每次修改只能+1");
                    }
                    _version = value;
                }
            }
        }

        public double CreateStamp
        {
            get
            {
                return _createStamp ?? DateTime.Now.TimeToStampMilliSecondDouble();
            }
            set
            {
                //允许修改一次，这行代码有bug【允许谁改，这个没控制好】
                if (_createTimeModifyTime == null)
                {
                    _createTimeModifyTime = 1;
                    _createStamp = value;
                }
            }
        }

        public double? DeleteStamp
        {
            get
            {
                return IsDelete ? _deleteStamp ?? DateTime.Now.TimeToStampMilliSecondDouble() : (double?)null;
            }
            set
            {
                if (_deleteStamp == null)
                    _deleteStamp = value;
            }
        }

        public bool IsDelete { get; set; }

        public double ModifyStamp
        {
            get
            {
                return _modifyStamp ?? DateTime.Now.TimeToStampMilliSecondDouble();
            }
            set { _modifyStamp = value; }
        }

        public virtual string GetStorageName()
        {
            return "Current";
        }
    }
}
