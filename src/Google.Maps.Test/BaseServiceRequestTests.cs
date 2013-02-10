using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps;

namespace Google.Maps.Test
{
    [TestFixture]
    public class BaseServiceRequestTests
    {

        public class BaseMapsServiceRequestImpl : BaseMapsServiceRequest
        {

            public new void EnsureSensor(bool throwIfNotSet)
            {
                base.EnsureSensor(throwIfNotSet);
            }

        }

        private BaseMapsServiceRequest CreateBaseMapsServiceRequest()
        {
            return new BaseMapsServiceRequestImpl();
        }

        [Test]
        public void Sensor_property_starts_as_not_set()
        {
            BaseMapsServiceRequest actual = CreateBaseMapsServiceRequest();

            Assert.IsNull(actual.Sensor); //property is supposed to start off null.
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnsureSensor_throwIfNotSet_eq_true_throws_InvalidOperationEx()
        {
            BaseMapsServiceRequest target = CreateBaseMapsServiceRequest();

            Assert.IsNull(target.Sensor); //property is supposed to start off null.

            target.EnsureSensor(true);
            //exception should've happened
        }
        [Test]
        public void EnsureSensor_throwIfNotSet_eq_false()
        {
            BaseMapsServiceRequest target = CreateBaseMapsServiceRequest();

            Assert.IsNull(target.Sensor); //property is supposed to start off null.

            bool returnValue = target.EnsureSensor(false);

            Assert.IsFalse(returnValue);
        }


    }
}
