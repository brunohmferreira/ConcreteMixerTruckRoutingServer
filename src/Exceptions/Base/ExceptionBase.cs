using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ConcreteMixerTruckRoutingServer.Exceptions.Base
{
    [Serializable]
    public abstract class ExceptionBase : Exception
    {
        #region Constructors

        protected ExceptionBase(string message) : base(message) { }

        protected ExceptionBase(SerializationInfo informations, StreamingContext context)
            : base(informations, context) { }

        #endregion

        #region Overrides

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            base.GetObjectData(info, context);
        }

        #endregion
    }
}
