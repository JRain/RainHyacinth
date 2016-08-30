using RainHyacinth.Lite;
using RainHyacinth.Lite.Imp;

namespace RainHyacinth.BLL
{
    public class OrmModel : RainLite
    {

    }
    public class OrmMap : RainLiteMap<OrmModel>, IRainLiteMap
    {
        public OrmMap() : base()
        {
        }
    }
}
